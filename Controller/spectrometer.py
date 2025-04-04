import ctypes
import numpy as np
import os
import matplotlib.pyplot as plt
from datetime import datetime

class SimpleSpectrometer:
    def __init__(self, channel=0):
        """Initialize the spectrometer with the selected channel."""
        self.channel = channel
        self.integration_time = 100  # Default integration time in ms
        self.gain = 1.0  # Default gain
        self.pixel_count = 2048  # Standard for many BWTek spectrometers
        
        # Path to the DLL
        dll_path = r"C:\Users\mozer\Documents\MESH\Projects_windows\BWTek-automatization\Controller\bwtekusb.dll"
        if not os.path.exists(dll_path):
            raise FileNotFoundError(f"DLL not found at {dll_path}")
        
        # Load the library
        self.lib = ctypes.cdll.LoadLibrary(dll_path)
        print("BWTek DLL loaded successfully")
        
        # Set up function access
        self.setup_functions()
        
        # Get model info
        self.model_info = self.get_model_info()
        print(f"Connected to device: {self.model_info}")

    def setup_functions(self):
        """Set up function access and argument types."""
        # Set up function access
        self.test_usb_func = self.lib.bwtekTestUSB
        self.read_eeprom_func = self.lib.bwtekReadEEPROMUSB
        self.close_func = self.lib.bwtekCloseUSB
        self.get_data_func = self.lib.bwtekGetDataUSB
        self.check_connection_func = self.lib.bwtekCheckConnection
        self.get_model_info_func = self.lib.bwtekGetModelInfo
        self.set_gain_func = self.lib.bwtekSetGain
        
        # Set function argument types
        self.test_usb_func.argtypes = [ctypes.c_int]
        self.test_usb_func.restype = ctypes.c_int
        
        self.read_eeprom_func.argtypes = [ctypes.c_char_p, ctypes.c_int]
        self.read_eeprom_func.restype = ctypes.c_int
        
        self.close_func.argtypes = [ctypes.c_int]
        self.close_func.restype = ctypes.c_int
        
        self.get_data_func.argtypes = [ctypes.c_void_p, ctypes.c_int]
        self.get_data_func.restype = ctypes.c_int
        
        self.check_connection_func.argtypes = [ctypes.c_int]
        self.check_connection_func.restype = ctypes.c_int
        
        # Assuming model info returns a string
        self.get_model_info_func.argtypes = [ctypes.c_char_p, ctypes.c_int]
        self.get_model_info_func.restype = ctypes.c_int
        
        self.set_gain_func.argtypes = [ctypes.c_float, ctypes.c_int]
        self.set_gain_func.restype = ctypes.c_int
    
    def __enter__(self):
        return self
    
    def __exit__(self, exc_type, exc_val, exc_tb):
        self.close()
    
    def initDevice(self):
        """Initialize the spectrometer using TestUSB as our init function."""
        print("Initializing BWTek device...")
        return self.test_usb_func(self.channel)
    
    def testUSB(self):
        """Test the USB connection to the device."""
        print("Testing USB connection...")
        return self.test_usb_func(self.channel)
    
    def readEEPROM(self, filename):
        """Read calibration data from the device's EEPROM."""
        print(f"Reading EEPROM data to {filename}...")
        return self.read_eeprom_func(filename.encode(), self.channel)
    
    def close(self):
        """Close the connection to the device."""
        print("Closing device connection...")
        return self.close_func(self.channel)
    
    def checkConnection(self):
        """Check if the device is connected."""
        return self.check_connection_func(self.channel)
    
    def get_model_info(self):
        """Get model information from the device."""
        buffer = ctypes.create_string_buffer(256)
        result = self.get_model_info_func(buffer, self.channel)
        if result == 0:
            return buffer.value.decode('utf-8', errors='ignore').strip()
        else:
            return f"Unknown model (error: {result})"
    
    @property
    def integrationTime(self):
        """Get the current integration time."""
        return self.integration_time
    
    @integrationTime.setter
    def integrationTime(self, value):
        """
        Set the integration time in milliseconds.
        
        Since we don't have a direct function to set integration time,
        we use the gain function as a proxy. The actual integration
        time is controlled by firmware.
        """
        print(f"Setting integration time to {value} ms...")
        self.integration_time = int(value)
        # We'll use set_gain as a proxy for timing control
        # This is approximate and may need adjustment
        gain_value = self.integration_time / 100.0  # Scale to reasonable gain
        return self.set_gain(gain_value)
    
    def set_gain(self, value):
        """Set the detector gain."""
        print(f"Setting detector gain to {value}...")
        self.gain = value
        return self.set_gain_func(ctypes.c_float(value), self.channel)
    
    def get_spectrum(self):
        """
        Get spectrum data from the spectrometer.
        
        Returns:
            tuple: (wavelengths, intensities)
        """
        # Number of pixels in the spectrometer
        buffer_size = self.pixel_count * 2  # 16-bit values = 2 bytes per pixel
        
        # Create buffer for spectrum data
        buffer = ctypes.create_string_buffer(buffer_size)
        
        # Get spectrum data
        print("Getting spectrum data...")
        result = self.get_data_func(buffer, self.channel)
        
        if result != 0:
            print(f"Warning: GetDataUSB returned error code {result}")
        
        # Convert buffer to intensity values
        intensities = np.frombuffer(buffer, dtype=np.uint16, count=self.pixel_count)
        
        # Calculate wavelengths using polynomial coefficients
        # These should be read from the EEPROM file in a production system
        a0 = 221.556159175733
        a1 = 0.52819936440007
        a2 = -5.4613963289515E-05
        a3 = -1.96442414820937E-09
        
        pixels = np.arange(self.pixel_count)
        wavelengths = a0 + a1*pixels + a2*pixels**2 + a3*pixels**3
        
        return wavelengths, intensities
    
    def save_spectrum(self, wavelengths, intensities, filename=None):
        """
        Save spectrum data to a file.
        
        Args:
            wavelengths: Array of wavelength values
            intensities: Array of intensity values
            filename: Optional filename, if None generates timestamp filename
        """
        if filename is None:
            timestamp = datetime.now().strftime("%Y%m%d_%H%M%S")
            filename = f"spectrum_{timestamp}.csv"
        
        # Save as CSV
        with open(filename, 'w') as f:
            f.write("Wavelength (nm),Intensity\n")
            for wl, intensity in zip(wavelengths, intensities):
                f.write(f"{wl:.6f},{intensity}\n")
        
        print(f"Saved spectrum data to {filename}")
        return filename
    
    def plot_spectrum(self, wavelengths, intensities, show=True, save=False, filename=None):
        """
        Plot the spectrum.
        
        Args:
            wavelengths: Array of wavelength values
            intensities: Array of intensity values
            show: Whether to display the plot
            save: Whether to save the plot
            filename: Optional filename for saved plot
        """
        plt.figure(figsize=(10, 6))
        plt.plot(wavelengths, intensities)
        plt.xlabel('Wavelength (nm)')
        plt.ylabel('Intensity')
        plt.title(f'BWTek Spectrometer Measurement\nGain: {self.gain}, Integration: {self.integration_time} ms')
        plt.grid(True)
        
        if save:
            if filename is None:
                timestamp = datetime.now().strftime("%Y%m%d_%H%M%S")
                filename = f"spectrum_{timestamp}.png"
            plt.savefig(filename)
            print(f"Saved plot to {filename}")
        
        if show:
            plt.show()
        else:
            plt.close()

