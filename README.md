# TaraSync
WinForms application implementing MVP pattern which synchronizes files in two folders.

#####How it works
TaraSync uses serialized *snapshot* from previous synchronization (Dictionary with file path as a key and file hash as a value) 
to synchronize files in folders.
*Snapshot* is created after synchronization and is stored in one of the synchronized folders. 
It is saved inside a newly created folder with *new guid* as a name. 
Same folder (but empty) is created in the other synchronized folder in order to identify next time 
if they were previously synchronized.

**Caution**: Be careful using this app. Don't make mess with your files :)
