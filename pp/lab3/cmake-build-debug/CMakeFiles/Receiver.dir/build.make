# CMAKE generated file: DO NOT EDIT!
# Generated by "NMake Makefiles" Generator, CMake Version 3.12

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

!IF "$(OS)" == "Windows_NT"
NULL=
!ELSE
NULL=nul
!ENDIF
SHELL = cmd.exe

# The CMake executable.
CMAKE_COMMAND = "C:\Program Files\JetBrains\CLion 2018.2.5\bin\cmake\win\bin\cmake.exe"

# The command to remove a file.
RM = "C:\Program Files\JetBrains\CLion 2018.2.5\bin\cmake\win\bin\cmake.exe" -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = E:\pp\lab3

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = E:\pp\lab3\cmake-build-debug

# Include any dependencies generated for this target.
include CMakeFiles\Receiver.dir\depend.make

# Include the progress variables for this target.
include CMakeFiles\Receiver.dir\progress.make

# Include the compile flags for this target's objects.
include CMakeFiles\Receiver.dir\flags.make

CMakeFiles\Receiver.dir\receiver.cpp.obj: CMakeFiles\Receiver.dir\flags.make
CMakeFiles\Receiver.dir\receiver.cpp.obj: ..\receiver.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=E:\pp\lab3\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/Receiver.dir/receiver.cpp.obj"
	"C:\Program Files (x86)\MICROS~4\2017\COMMUN~1\VC\Tools\MSVC\1415~1.267\bin\Hostx86\x86\cl.exe" @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) /FoCMakeFiles\Receiver.dir\receiver.cpp.obj /FdCMakeFiles\Receiver.dir\ /FS -c E:\pp\lab3\receiver.cpp
<<

CMakeFiles\Receiver.dir\receiver.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/Receiver.dir/receiver.cpp.i"
	"C:\Program Files (x86)\MICROS~4\2017\COMMUN~1\VC\Tools\MSVC\1415~1.267\bin\Hostx86\x86\cl.exe" > CMakeFiles\Receiver.dir\receiver.cpp.i @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E E:\pp\lab3\receiver.cpp
<<

CMakeFiles\Receiver.dir\receiver.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/Receiver.dir/receiver.cpp.s"
	"C:\Program Files (x86)\MICROS~4\2017\COMMUN~1\VC\Tools\MSVC\1415~1.267\bin\Hostx86\x86\cl.exe" @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) /FoNUL /FAs /FaCMakeFiles\Receiver.dir\receiver.cpp.s /c E:\pp\lab3\receiver.cpp
<<

# Object files for target Receiver
Receiver_OBJECTS = \
"CMakeFiles\Receiver.dir\receiver.cpp.obj"

# External object files for target Receiver
Receiver_EXTERNAL_OBJECTS =

Receiver.exe: CMakeFiles\Receiver.dir\receiver.cpp.obj
Receiver.exe: CMakeFiles\Receiver.dir\build.make
Receiver.exe: CMakeFiles\Receiver.dir\objects1.rsp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=E:\pp\lab3\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX executable Receiver.exe"
	"C:\Program Files\JetBrains\CLion 2018.2.5\bin\cmake\win\bin\cmake.exe" -E vs_link_exe --intdir=CMakeFiles\Receiver.dir --manifests  -- "C:\Program Files (x86)\MICROS~4\2017\COMMUN~1\VC\Tools\MSVC\1415~1.267\bin\Hostx86\x86\link.exe" /nologo @CMakeFiles\Receiver.dir\objects1.rsp @<<
 /out:Receiver.exe /implib:Receiver.lib /pdb:E:\pp\lab3\cmake-build-debug\Receiver.pdb /version:0.0  /machine:X86 /debug /INCREMENTAL /subsystem:console kernel32.lib user32.lib gdi32.lib winspool.lib shell32.lib ole32.lib oleaut32.lib uuid.lib comdlg32.lib advapi32.lib 
<<

# Rule to build all files generated by this target.
CMakeFiles\Receiver.dir\build: Receiver.exe

.PHONY : CMakeFiles\Receiver.dir\build

CMakeFiles\Receiver.dir\clean:
	$(CMAKE_COMMAND) -P CMakeFiles\Receiver.dir\cmake_clean.cmake
.PHONY : CMakeFiles\Receiver.dir\clean

CMakeFiles\Receiver.dir\depend:
	$(CMAKE_COMMAND) -E cmake_depends "NMake Makefiles" E:\pp\lab3 E:\pp\lab3 E:\pp\lab3\cmake-build-debug E:\pp\lab3\cmake-build-debug E:\pp\lab3\cmake-build-debug\CMakeFiles\Receiver.dir\DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles\Receiver.dir\depend

