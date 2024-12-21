using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.ValueTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    ChangeDirectoryResult ChangeDirectory(string path);

    ListDirectoryResult ListDirectory(TreeDepth depth);

    ReadFileResult ReadFile(string path);

    MoveFileResult MoveFile(string sourcePath, string destinationPath);

    CopyFileResult CopyFile(string sourcePath, string destinationPath);

    DeleteFileResult DeleteFile(string path);

    RenameFileResult RenameFile(string path, string newName);

    string ParsePathToAbsolute(string path);

    bool DirectoryExists(string path);

    bool FileExists(string path);
}