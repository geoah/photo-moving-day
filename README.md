Photo Moving Day
================

Lists all photographs of the source folder. (Optionally all files)
Tried to retrieve the date and time the photograph was taken from its EXIF data.
(Optionally if this fails it can retrieve the oldest date and time - either creation date or last write time - from the file's attributes.)
Creates a folder in the destination using the format "yyyy-mm-dd".
(Optionally if a photograph with the same folder and file name already exists deletes it from the destination folder.)
Copies the photograph into that folder. (Optionally moves instead of copying).

All actions are logged.

Log messages
------------
Copied "C:\photographs-source\DSC_0000.jpg" to "C:\photographs-source\2012-11-27\DSC_0000.jpg"
Moved "C:\photographs-source\DSC_0000.jpg" to "C:\photographs-source\2012-11-27\DSC_0000.jpg"
Warning: File "C:\photographs-source\DSC_0000.jpg" already exists as "C:\photographs-source\2012-11-27\DSC_0000.jpg"