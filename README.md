# DeleteOldFiles
This is a small utility written in F# to delete old files in a folder (and all subfolders if `-r` option is given on the command line) while keeping a specified number of files.

    USAGE: DeleteOldFiles.exe <directory> <maxFileCount> [-r]

* `<directory>` is the root folder where files will be deleted. 
  if the `-r` option is specified all subfolders are recursively considered.
* `<maxFileCount>` is the maximum number of files to keep. note that when searching recursively (`-r` option) the `<maxFileCount>` is the total number of files over all the subfolders and not the maximum count in each folder.

The files will be sorted descendingly according to their last modification date and the first `<maxFileCount>` files will be kept while the rest is deleted.
