import ctypes
import os

def list_dll_functions(dll_path):
    """
    Lists all the functions exported by a DLL file.

    Args:
        dll_path (str): Path to the DLL file.
    """
    if not os.path.exists(dll_path):
        print(f"Error: The file '{dll_path}' does not exist.")
        return

    try:
        # Load the DLL
        dll = ctypes.WinDLL(dll_path)
        
        # Use the ctypes `__all__` attribute to list functions
        functions = dir(dll)
        
        print(f"Functions in '{dll_path}':")
        for func in functions:
            print(func)
    except Exception as e:
        print(f"Error loading DLL: {e}")

if __name__ == "__main__":
    # Replace this with the path to your DLL file
    dll_path = r"C:\Users\User\Documents\Programming\BWTek-automatization\BWTek\VER1.3\BWTEKUSB.DLL"
    list_dll_functions(dll_path)