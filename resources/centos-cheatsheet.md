# CentOS Admin Cheat Sheet

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

`rm -f <file>` - forcefully remove file

`rm -r <dir>` - remove directory

`cp srcfile destfile` - copy file

`cp -r srcdir destdir` - copy directory

### File permissions

`chmod 777 file` - set rwx for owner.group.world

`chmod 755 file` - set rwx for owner and rw for group.world

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