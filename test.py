from datetime import datetime
import matplotlib.pyplot as plt
from Controller.spectrometer import SimpleSpectrometer
import numpy as np

def run_pl_measurement(
    integration_time=100,
    gain=1.0,
    save_data=True,
    show_plot=True,
    wavelength_range=None,
    num_measurements=1,
    average_scans=True,
    dark_correction=False,
    smooth_data=False,
    custom_filename=None
):
    """
    Args:
        integration_time: Integration time in milliseconds
        gain: Detector gain value
        save_data: Whether to save the data to a file
        show_plot: Whether to show the plot
        wavelength_range: Optional tuple (min_wl, max_wl) to restrict wavelength range
        num_measurements: Number of consecutive measurements to perform
        average_scans: Whether to average multiple measurements (True) or return all (False)
        dark_correction: Whether to perform dark spectrum subtraction
        smooth_data: Whether to apply smoothing to the spectrum
        custom_filename: Custom base filename for saving data
    
    Returns:
        If average_scans=True: (wavelengths, intensities)
        If average_scans=False: (wavelengths, list_of_intensities)
    """
    timestamp = datetime.now().strftime("%Y%m%d_%H%M%S")
    filename_base = custom_filename if custom_filename else f"pl_spectrum_{timestamp}"
    
    # Store results from multiple measurements
    all_intensities = []
    
    with SimpleSpectrometer(0) as spec:
        # Initialize the device
        status = spec.initDevice()
        if status != 0:
            print(f"Warning: Device initialization returned status {status}")
        
        # Read EEPROM data
        eeprom_file = f"calibration_{timestamp}.dat"
        spec.readEEPROM(eeprom_file)
        
        # Set measurement parameters
        spec.integrationTime = integration_time
        spec.set_gain(gain)
        
        # Check connection
        connection = spec.checkConnection()
        print(f"Connection status: {connection}")
        
        # Acquire dark spectrum if requested
        dark_intensities = None
        if dark_correction:
            print("Acquiring dark spectrum...")
            # You would need to implement a way to block light or turn off excitation
            # This is just a placeholder for the concept
            _, dark_intensities = spec.get_spectrum()
        
        # Perform multiple measurements
        for i in range(num_measurements):
            print(f"Taking measurement {i+1} of {num_measurements}...")
            
            # Get spectrum data
            wavelengths, intensities = spec.get_spectrum()
            
            # Apply dark correction if requested
            if dark_correction and dark_intensities is not None:
                intensities = intensities - dark_intensities
                intensities = np.maximum(intensities, 0)  # Ensure no negative values
            
            # Apply wavelength range restriction if specified
            if wavelength_range:
                min_wl, max_wl = wavelength_range
                mask = (wavelengths >= min_wl) & (wavelengths <= max_wl)
                wavelengths = wavelengths[mask]
                intensities = intensities[mask]
            
            # Apply smoothing if requested
            if smooth_data:
                intensities = smooth_spectrum(intensities)
            
            all_intensities.append(intensities)
            
            # Save individual data if requested and not averaging
            if save_data and not average_scans:
                data_file = f"{filename_base}_scan{i+1}.csv"
                spec.save_spectrum(wavelengths, intensities, data_file)
        
        # Process results based on averaging option
        if average_scans and num_measurements > 1:
            intensities = np.mean(all_intensities, axis=0)
            print(f"Averaged {num_measurements} measurements")
            
            # Save averaged data if requested
            if save_data:
                data_file = f"{filename_base}_averaged.csv"
                spec.save_spectrum(wavelengths, intensities, data_file)
        else:
            intensities = all_intensities
        
        # Plot the data
        if show_plot:
            if average_scans or num_measurements == 1:
                plot_file = f"{filename_base}.png" if save_data else None
                spec.plot_spectrum(wavelengths, intensities, show=True, save=save_data, filename=plot_file)
            else:
                # Plot multiple spectra
                plt.figure(figsize=(10, 6))
                for i, intens in enumerate(intensities):
                    plt.plot(wavelengths, intens, label=f"Scan {i+1}")
                
                plt.xlabel('Wavelength (nm)')
                plt.ylabel('Intensity')
                plt.title(f'BWTek Spectrometer: Multiple Measurements\n'
                          f'Integration: {integration_time} ms, Gain: {gain}')
                plt.grid(True)
                plt.legend()
                
                if save_data:
                    plot_file = f"{filename_base}_multi.png"
                    plt.savefig(plot_file)
                    print(f"Saved multi-scan plot to {plot_file}")
                
                if show_plot:
                    plt.show()
                else:
                    plt.close()
        
        print("PL measurement completed successfully")
        return wavelengths, intensities


def smooth_spectrum(intensities, window_size=5):
    """Apply simple moving average smoothing to spectrum data."""
    return np.convolve(intensities, np.ones(window_size)/window_size, mode='same')

if __name__ == "__main__":
    run_pl_measurement(integration_time=100, gain=1.0)