using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.ValueTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class NullFileSystem : IFileSystem
{
    public ChangeDirectoryResult ChangeDirectory(string path)
    {
        return new ChangeDirectoryResult.Failure();
    }

    public ListDirectoryResult ListDirectory(TreeDepth depth)
    {
        return new ListDirectoryResult.Failure();
    }

    public ReadFileResult ReadFile(string path)
    {
        return new ReadFileResult.Failure();
    }

    public MoveFileResult MoveFile(string sourcePath, string destinationPath)
    {
        return new MoveFileResult.Failure();
    }

    public CopyFileResult CopyFile(string sourcePath, string destinationPath)
    {
        return new CopyFileResult.Failure();
    }

    public DeleteFileResult DeleteFile(string path)
    {
        return new DeleteFileResult.Failure();
    }

    public RenameFileResult RenameFile(string path, string newName)
    {
        return new RenameFileResult.Failure();
    }

    public string ParsePathToAbsolute(string path)
    {
        return path;
    }

    public bool DirectoryExists(string path)
    {
        return false;
    }

    public bool FileExists(string path)
    {
        return false;
    }
}