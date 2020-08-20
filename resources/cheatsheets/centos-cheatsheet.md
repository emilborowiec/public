# CentOS Admin Cheat Sheet

## Linux Shell

### Console

`clear` - clears the screen.

`sort` - sorts the output.

`more` - load file or output and show to console. Navigate with enter and space. Exit with q.

`less` - like more. Does not load all content. Navigate also with arrows.

`less \word` - highlight searched word in the output.

`grep <pattern> [[-r] file]` - search for pattern in output, or file or directory 

### User management

`getent passwd` - shows list of users

`getent group` - shows list of groups

`adduser <username>` - adds user

`userdel <username>` - deletes user

`groupadd <groupname>` - adds group

`groupdel <groupname>` - deletes group

`usermod -aG <group> <username>` - adds user to the group

`usermod -aG wheel <username` - adds user to sudo group

### File system

`ls -la` - list contents of directory with hidden files

`find <dir> [-group <group-name>] [-user <user-name>] [-name <filename>]` - find files owned by group or user

`mkdir <dir>` - create directory

`rm <file>` - remove file

`rm -f file` - forcefully remove file

`rm -r dir/` - remove directory

`rm -r dir_symlink` - without trailing / you can remove symlink to dir

`cp srcfile destfile` - copy file

`cp -r srcdir destdir` - copy directory

`ln -s file symlink` - create symlink to file

`mv oldfilename newfilename` - move file

### File permissions

`chmod 777 file` - set rwx for owner.group.world

`chmod 755 file` - set rwx for owner and rw for group.world

`1 for x; 2 for w; 4 for r` - chmod binary codes

`chown owner-user.owner-group file-or-dir`

### Disk usage

### Services

`systemctl | sort | less` - list systemd services 

`systemctl list-unit-files | sort | less` - list systemd unit files with their state 

### SSH

`cat <your_public_key_file> >> ~/.ssh/authorized_keys` - adds public key to authorized keys

`vi /etc/hosts` - edit hosts file to allow connecting with dns name

### Remote control

`ssh user@host -p port` - connect to the server with ssh

`scp -P port source user@host:destination` - copy source file to destination file with ssh

`scp -P port -r source user@host:destination` - copy source dir to destination dir with ssh

## vim

### All commands

`[count][command]` - format of vi commands allowing repeat count times

### Modes

`Esc` - enter command mode

`a` - append after cursor (enter input mode)

`i` - insert before cursor (enter input mode)

`o` - open line below (enter input mode)

`O` - open line above (enter input mode)

### File management commands

`:w name` - write to file name

`:wq` or `ZZ` - write to file and quit

`:q!` - quit without saving changes

### Change commands

`cw` - change word

`cc` - change line

`C` - change to end of line

`r` - replace one character

`R` - replace many (typeover)

`s` - substitute one character with string

`S` - substitute rest of line with text

`*` - repeat last change

### Deleting commands

`x` - del

`X` - backspace

`D` - delete to end of line

`dd` - delete (actually cut) current line

### Copying and pasting

`Y` or `yy` - copy line

`p` - paste below

`P` - paste above