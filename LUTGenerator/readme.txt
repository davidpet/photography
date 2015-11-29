1) Create RGB reference tiff with desired matrix params
2) "Assign" the profile that this lut will be meant for in Photoshop to lock in the source interpretation of the linearly scaled matrix
3) Convert to 16-bit to avoid losing data in the conversions
4) "Convert" to the profile that will serve as the intermediary, affecting the look of the conversions
5) Perform whatever filters you want in the intermediary color space
6) "Convert" back to the profile the LUT is meant for and switch image mode to 8-bit
7) save as a lossless tiff with no embedded profile
8) Load the tiff in LUTGenerator and create a LUT for it
*steps 2 and 6 determine what color space the LUT is meant to be used in
*step 4 determines the overall look (for instance, if the filter you apply was meant to be done in linear and looks best that way)
