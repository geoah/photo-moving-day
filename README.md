Photo Moving Day
================

Lists all photographs of the source folder. (Optionally all files)  
Tried to retrieve the date and time the photograph was taken from its EXIF data.  
(Optionally if this fails it can retrieve the oldest date and time - either creation date or last write time - from the file's attributes.)  
Creates a folder in the destination using the format "yyyy-mm-dd".  
(Optionally if a photograph with the same folder and file name already exists deletes it from the destination folder.)  
Copies the photograph into that folder. (Optionally moves instead of copying).  

![Interface](https://dl.dropbox.com/u/200262/Shared/photo-moving-day-1.2.PNG "Interface")

Log messages
------------
All actions are logged.

```Copied "C:\photographs-source\DSC_0000.jpg" to "C:\photographs-source\2012-11-27\DSC_0000.jpg"```
```Moved "C:\photographs-source\DSC_0000.jpg" to "C:\photographs-source\2012-11-27\DSC_0000.jpg"```
```Warning: File "C:\photographs-source\DSC_0000.jpg" already exists as "C:\photographs-source\2012-11-27\DSC_0000.jpg"```  

Sample destination structure
----------------------------
The application will create a structure similar to this one.

```
C:\destination\2005-05-08
	0416.jpg

C:\destination\2005-05-09
	0417.jpg
	0418.jpg
	0419.jpg

C:\destination\2005-05-10
	0420.jpg

C:\destination\2005-05-13
	0421.jpg
	0422.jpg
	0423.jpg
	0424.jpg

C:\destination\2005-05-16
	0436.jpg
	0437.jpg
	0438.jpg
	0439.jpg
	0440.jpg
	0441.jpg
	0442.jpg
	0443.jpg
	0444.jpg

C:\destination\2005-05-27
	0445.jpg
	0446.jpg
	0447.jpg
	0448.jpg

C:\destination\2005-05-29
	0575.jpg
	0576.jpg
	0577.jpg
	0578.jpg
```