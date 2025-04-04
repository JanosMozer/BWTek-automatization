import numpy as np
import matplotlib.pyplot as plt
from Controller.devices.bwtek.spectrometer import spectrometer
from lantz import Q_
from ctypes import c_int, c_ulong, POINTER, create_string_buffer

def run_measurement():
    # Initialize the spectrometer (channel 0)
    with spectrometer(0) as spec:
        # Initialize the device
        status = spec.initDevice()
        print(f"Device initialization status: {status}")
        
        # Read EEPROM data
        spec.readEEPROM("calibration.dat")
        
        # Test USB connection
        connection_status = spec.testUSB()
        print(f"USB connection test: {connection_status}")
        
        # Set integration time (100 milliseconds)
        spec.integrationTime = 100 * Q_('ms')
        print(f"Integration time set to: {spec.integrationTime}")
        
        # Get spectrum data from the spectrometer
        wavelengths, intensities = get_spectrum_data(spec)
        
        # Plot the spectrum
        plt.figure(figsize=(10, 6))
        plt.plot(wavelengths, intensities)
        plt.xlabel('Wavelength (nm)')
        plt.ylabel('Intensity')
        plt.title('BWTek Spectrometer Measurement')
        plt.grid(True)
        plt.savefig('spectrum.png')
        plt.show()
        
        # Close the connection
        spec.close()
        print("Measurement completed successfully")

def get_spectrum_data(spec):
    """
    Get spectral data from the spectrometer
    """
    # Number of pixels in the spectrometer
    pixel_count = 2048
    
    # Create a buffer to store the spectral data
    # Each pixel value is represented as an unsigned 16-bit integer (2 bytes)
    buffer_size = pixel_count * 2
    buffer = create_string_buffer(buffer_size)
    
    # Call the BWTek library function to read spectral data
    # Based on the naming convention in other methods
    result = spec.lib.bwtekGetSpectrumUSB(buffer, spec.channel)
    
    if result != 0:
        print(f"Error reading spectrum data. Error code: {result}")
        # Return dummy data in case of error
        return np.zeros(pixel_count), np.zeros(pixel_count)
    
    # Convert buffer to numpy array of intensity values
    # The data is stored as 16-bit unsigned integers
    intensities = np.frombuffer(buffer, dtype=np.uint16, count=pixel_count)
    
    # Convert pixel indices to wavelengths using calibration coefficients
    # These coefficients are from the 't' configuration file
    a0 = 221.556159175733
    a1 = 0.52819936440007
    a2 = -5.4613963289515E-05
    a3 = -1.96442414820937E-09
    
    wavelengths = np.zeros(pixel_count)
    for i in range(pixel_count):
        wavelengths[i] = a0 + a1*i + a2*i*i + a3*i*i*i
    
    return wavelengths, intensities

if __name__ == "__main__":
    run_measurement()