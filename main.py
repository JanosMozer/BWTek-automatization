import time
from datetime import datetime
import numpy as np
import matplotlib.pyplot as plt
from ctypes import CDLL, c_int, c_double, POINTER, create_string_buffer

# Load the BWTek DLL
bwtek_dll = CDLL(r"c:\Users\User\Documents\Programming\BWTek-automatization\BWTek\SDK-SL Download\Current SDK-SL Software\SDK-SL v1.0.0.9 Installation\64bit\DLL_64bit\BWTEKUSB.dll")

def log_message(message, log_file="measurement_log.txt"):
    """Log messages to both a file and the terminal."""
    timestamp = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    formatted_message = f"[{timestamp}] {message}"
    
    # Log to the terminal
    print(formatted_message)
    
    # Log to the file
    with open(log_file, "a") as f:
        f.write(formatted_message + "\n")

def pl_measurement(
    integration_time=100,
    interval=1,
    num_measurements=10,
    save_data=True,
    show_plot=True,
    custom_filename=None,
    wavelength_range=(0, 1500),
    perform_dark_correction=False
):

    try:
        timestamp = datetime.now().strftime("%Y%m%d_%H%M%S")
        filename_base = custom_filename if custom_filename else f"pl_measurement_{timestamp}"

        # Initialize the spectrometer
        if not bwtek_dll.InitDevices():
            log_message("Error: Failed to initialize the spectrometer.")
            return

        device_count = bwtek_dll.GetDeviceCount()
        if device_count <= 0:
            log_message("Error: No spectrometer devices found.")
            return

        channel = 0  # Assuming single device
        bwtek_dll.bwtekSetTimeUSB_2(c_int(integration_time), c_int(1), c_int(channel))

        wavelengths = np.zeros(2048, dtype=np.float64)
        intensities = np.zeros(2048, dtype=np.float64)
        all_intensities = []

        # Perform dark spectrum measurement if requested
        dark_spectrum = None
        if perform_dark_correction:
            log_message("Acquiring dark spectrum...")
            wavelength_ptr = wavelengths.ctypes.data_as(POINTER(c_double))
            intensity_ptr = intensities.ctypes.data_as(POINTER(c_double))
            bwtek_dll.bwtekReadValue(c_int(0), wavelength_ptr, c_int(channel))
            bwtek_dll.bwtekReadValue(c_int(1), intensity_ptr, c_int(channel))
            dark_spectrum = intensities.copy()
            log_message("Dark spectrum acquired.")

        for i in range(num_measurements):
            log_message(f"Performing measurement {i + 1}/{num_measurements}...")

            # Read spectrum
            wavelength_ptr = wavelengths.ctypes.data_as(POINTER(c_double))
            intensity_ptr = intensities.ctypes.data_as(POINTER(c_double))
            bwtek_dll.bwtekReadValue(c_int(0), wavelength_ptr, c_int(channel))
            bwtek_dll.bwtekReadValue(c_int(1), intensity_ptr, c_int(channel))

            # Apply dark spectrum subtraction
            if perform_dark_correction and dark_spectrum is not None:
                intensities -= dark_spectrum
                intensities = np.maximum(intensities, 0)  # Ensure no negative values

            # Apply wavelength range filter
            min_wl, max_wl = wavelength_range
            mask = (wavelengths >= min_wl) & (wavelengths <= max_wl)
            filtered_wavelengths = wavelengths[mask]
            filtered_intensities = intensities[mask]

            all_intensities.append(filtered_intensities)

            # Save individual measurement
            if save_data:
                data_file = f"{filename_base}_scan{i + 1}.csv"
                np.savetxt(data_file, np.column_stack((filtered_wavelengths, filtered_intensities)), delimiter=",", header="Wavelength,Intensity")
                log_message(f"Saved data to {data_file}")

            # Wait for the next measurement
            if i < num_measurements - 1:
                time.sleep(interval)

        # Average the measurements
        averaged_intensities = np.mean(all_intensities, axis=0)

        # Save averaged data
        if save_data:
            avg_file = f"{filename_base}_averaged.csv"
            np.savetxt(avg_file, np.column_stack((filtered_wavelengths, averaged_intensities)), delimiter=",", header="Wavelength,Intensity")
            log_message(f"Saved averaged data to {avg_file}")

        # Plot the results
        if show_plot:
            plt.figure(figsize=(10, 6))
            plt.plot(filtered_wavelengths, averaged_intensities, label="Averaged Spectrum")
            plt.xlabel("Wavelength (nm)")
            plt.ylabel("Intensity")
            plt.title("PL Measurement")
            plt.grid(True)
            plt.legend()
            plt.show()

        # Close the spectrometer
        bwtek_dll.CloseDevices()
        log_message("Spectrometer closed successfully.")

        return filtered_wavelengths, averaged_intensities

    except Exception as e:
        log_message(f"Error occurred: {e}")
        bwtek_dll.CloseDevices()

if __name__ == "__main__":
    pl_measurement(
        integration_time=200,
        interval=2,
        num_measurements=5,
        wavelength_range=(400, 800),
        perform_dark_correction=True
    )