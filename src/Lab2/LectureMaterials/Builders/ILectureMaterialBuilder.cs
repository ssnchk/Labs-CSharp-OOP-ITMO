using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials.Builders;

public interface ILectureMaterialBuilder
{
    public ILectureMaterialBuilder WithName(string name);

    public ILectureMaterialBuilder WithAuthor(User author);

    public ILectureMaterialBuilder WithDescription(string description);

    public ILectureMaterialBuilder WithId(Guid id);

    public ILectureMaterialBuilder WithContext(string context);

    ILectureMaterial Build();
}