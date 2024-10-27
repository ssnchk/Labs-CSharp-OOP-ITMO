using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;

public interface ISubjectsBuilder
{
    public ISubjectsBuilder WithCurrentUser(User user);

    public ISubjectsBuilder WithName(string name);

    public ISubjectsBuilder WithAuthor(User author);

    public ISubjectsBuilder AddLaboratoryWork(ILaboratoryWork laboratoryWork);

    public ISubjectsBuilder AddLectureMaterial(ILectureMaterial lectureMaterial);

    public ISubject Build();
}