using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Xunit;

namespace Lab2.Tests;

public class EducationalProgramTests
{
    [Fact]
    public void ChangingLaboratoryWork_ShouldReturn_Failure_WhenChangingNotByAuthor()
    {
        // Arrange
        var author = new User("ssnchk", Guid.NewGuid());
        var notAuthor = new User("not_ssnchk", Guid.NewGuid());

        var laboratoryWorkBuilder = new LaboratoryWorkBuilder();
        laboratoryWorkBuilder.WithAuthor(author);
        laboratoryWorkBuilder.WithName("lab1");
        laboratoryWorkBuilder.WithId(Guid.NewGuid());
        laboratoryWorkBuilder.WithPointsAmount(new Points(10));
        laboratoryWorkBuilder.WithDescription("some description");
        laboratoryWorkBuilder.WithCurrentUser(author);

        ILaboratoryWork laboratoryWork = laboratoryWorkBuilder.Build();

        // Act
        SetNameResult setNameResulWithRightAuthor = laboratoryWork.SetName("lab2");
        SetCriteriasResult setCriteriasResultWithRightAuthor = laboratoryWork.SetCriterias(new List<string>());
        SetDescriptionResult setDescriptionResultWithRightAuthor =
            laboratoryWork.SetDescription("some description");

        laboratoryWork.SetCurrentUser(notAuthor);

        SetNameResult setNameResultWithWrongAuthor = laboratoryWork.SetName("lab2");
        SetCriteriasResult setCriteriasResultWithWrongAuthor =
            laboratoryWork.SetCriterias(new List<string>());
        SetDescriptionResult setDescriptionResultWithWrongAuthor =
            laboratoryWork.SetDescription("some description");

        // Assert
        Assert.IsType<SetNameResult.Failure>(setNameResultWithWrongAuthor);
        Assert.IsType<SetNameResult.Success>(setNameResulWithRightAuthor);

        Assert.IsType<SetCriteriasResult.Failure>(setCriteriasResultWithWrongAuthor);
        Assert.IsType<SetCriteriasResult.Success>(setCriteriasResultWithRightAuthor);

        Assert.IsType<SetDescriptionResult.Failure>(setDescriptionResultWithWrongAuthor);
        Assert.IsType<SetDescriptionResult.Success>(setDescriptionResultWithRightAuthor);
    }

    [Fact]
    public void ChangingLectureMaterial_ShouldReturn_Failure_WhenChangingNotByAuthor()
    {
        // Arrange
        var author = new User("ssnchk", Guid.NewGuid());
        var notAuthor = new User("not_ssnchk", Guid.NewGuid());

        var lectureMaterialBuilder = new LectureMaterialBuilder();
        lectureMaterialBuilder.WithAuthor(author);
        lectureMaterialBuilder.WithName("lab1");
        lectureMaterialBuilder.WithId(Guid.NewGuid());
        lectureMaterialBuilder.WithDescription("some description");
        lectureMaterialBuilder.WithContext("some context");
        lectureMaterialBuilder.WithCurrentUser(author);

        ILectureMaterial lectureMaterial = lectureMaterialBuilder.Build();

        // Act
        SetNameResult setNameResulWithRightAuthor = lectureMaterial.SetName("lab2");
        SetDescriptionResult setDescriptionResultWithRightAuthor =
            lectureMaterial.SetDescription("some description");
        SetContextResult setContextResultWithRightAuthor = lectureMaterial.SetContext("some context");

        lectureMaterial.SetCurrentUser(notAuthor);

        SetNameResult setNameResultWithWrongAuthor = lectureMaterial.SetName("lab2");
        SetDescriptionResult setDescriptionResultWithWrongAuthor =
            lectureMaterial.SetDescription("some description");
        SetContextResult setContextResultWithWrongAuthor = lectureMaterial.SetContext("some context");

        // Assert
        Assert.IsType<SetNameResult.Failure>(setNameResultWithWrongAuthor);
        Assert.IsType<SetNameResult.Success>(setNameResulWithRightAuthor);

        Assert.IsType<SetDescriptionResult.Failure>(setDescriptionResultWithWrongAuthor);
        Assert.IsType<SetDescriptionResult.Success>(setDescriptionResultWithRightAuthor);

        Assert.IsType<SetContextResult.Failure>(setContextResultWithWrongAuthor);
        Assert.IsType<SetContextResult.Success>(setContextResultWithRightAuthor);
    }

    [Fact]
    public void ChangingSubjects_ShouldReturn_Failure_WhenChangingNotByAuthor()
    {
        // Arrange
        var author = new User("ssnchk", Guid.NewGuid());
        var notAuthor = new User("not_ssnchk", Guid.NewGuid());

        var laboratoryWorkBuilder = new LaboratoryWorkBuilder();
        laboratoryWorkBuilder.WithAuthor(author);
        laboratoryWorkBuilder.WithName("lab1");
        laboratoryWorkBuilder.WithId(Guid.NewGuid());
        laboratoryWorkBuilder.WithPointsAmount(new Points(100));
        laboratoryWorkBuilder.WithDescription("some description");
        laboratoryWorkBuilder.WithCurrentUser(author);

        ILaboratoryWork laboratoryWork = laboratoryWorkBuilder.Build();

        var examSubjectBuilder = new ExamSubjectBuilder();
        examSubjectBuilder.WithAuthor(author);
        examSubjectBuilder.WithName("lab1");
        examSubjectBuilder.WithId(Guid.NewGuid());
        examSubjectBuilder.WithPoints(new Points(10));
        examSubjectBuilder.AddLaboratoryWork(laboratoryWork);
        examSubjectBuilder.WithCurrentUser(author);

        ISubject examSubject = examSubjectBuilder.Build();

        var testSubjectBuilder = new TestSubjectBuilder();
        testSubjectBuilder.WithAuthor(author);
        testSubjectBuilder.WithName("lab1");
        testSubjectBuilder.WithId(Guid.NewGuid());
        testSubjectBuilder.WithMinSuccessPoints(new Points(10));
        testSubjectBuilder.AddLaboratoryWork(laboratoryWork);
        testSubjectBuilder.WithCurrentUser(author);

        ISubject testSubject = testSubjectBuilder.Build();

        // Act
        SetNameResult setNameResulForExamSubjectWithRightAuthor = examSubject.SetName("lab2");
        SetNameResult setNameResulForTestSubjectWithRightAuthor = testSubject.SetName("lab2");

        examSubject.SetCurrentUser(notAuthor);
        testSubject.SetCurrentUser(notAuthor);

        SetNameResult setNameResultForExamSubjectWithWrongAuthor = examSubject.SetName("lab2");
        SetNameResult setNameResultForTestSubjectWithWrongAuthor = testSubject.SetName("lab2");

        // Assert
        Assert.IsType<SetNameResult.Failure>(setNameResultForExamSubjectWithWrongAuthor);
        Assert.IsType<SetNameResult.Success>(setNameResulForExamSubjectWithRightAuthor);

        Assert.IsType<SetNameResult.Failure>(setNameResultForTestSubjectWithWrongAuthor);
        Assert.IsType<SetNameResult.Success>(setNameResulForTestSubjectWithRightAuthor);
    }

    [Fact]
    public void ClonedLaboratoryWork_ShouldHaveNewId_And_InitialId_And_Throw_WhenIdsAreEqual()
    {
        // Arrange
        var originalId = Guid.NewGuid();
        var author = new User("ssnchk", Guid.NewGuid());

        var laboratoryWorkBuilder = new LaboratoryWorkBuilder();
        laboratoryWorkBuilder.WithAuthor(author);
        laboratoryWorkBuilder.WithName("lab1");
        laboratoryWorkBuilder.WithId(originalId);
        laboratoryWorkBuilder.WithPointsAmount(new Points(10));
        laboratoryWorkBuilder.WithDescription("some description");
        laboratoryWorkBuilder.WithCurrentUser(author);

        var laboratoryWork = (ILaboratoryWork<LaboratoryWork>)laboratoryWorkBuilder.Build();

        // Act
        ILaboratoryWork clonedLaboratoryWorkWithNewId =
            laboratoryWork.Clone(Guid.NewGuid());

        // Assert
        Assert.NotEqual(laboratoryWork.Id, clonedLaboratoryWorkWithNewId.Id);
        Assert.Equal(laboratoryWork.Id, clonedLaboratoryWorkWithNewId.ParentId);

        Assert.Throws<ArgumentException>(() => laboratoryWork.Clone(originalId));
    }

    [Fact]
    public void ClonedLectureMaterial_ShouldHaveNewId_And_InitialId_And_Throw_WhenIdsAreEqual()
    {
        // Arrange
        var originalId = Guid.NewGuid();
        var author = new User("ssnchk", Guid.NewGuid());

        var lectureMaterialBuilder = new LectureMaterialBuilder();
        lectureMaterialBuilder.WithAuthor(author);
        lectureMaterialBuilder.WithName("lab1");
        lectureMaterialBuilder.WithId(originalId);
        lectureMaterialBuilder.WithDescription("some description");
        lectureMaterialBuilder.WithContext("some context");
        lectureMaterialBuilder.WithCurrentUser(author);

        var lectureMaterial = (ILectureMaterial<LectureMaterial>)lectureMaterialBuilder.Build();

        // Act
        ILectureMaterial clonedLectureMaterialWithNewId =
            lectureMaterial.Clone(Guid.NewGuid());

        // Assert
        Assert.NotEqual(lectureMaterial.Id, clonedLectureMaterialWithNewId.Id);
        Assert.Equal(lectureMaterial.Id, clonedLectureMaterialWithNewId.ParentId);

        Assert.Throws<ArgumentException>(() => lectureMaterial.Clone(originalId));
    }

    [Fact]
    public void ClonedSubject_ShouldHaveNewId_And_InitialId_And_Throw_WhenIdsAreEqual()
    {
        // Arrange
        var originalId = Guid.NewGuid();
        var author = new User("ssnchk", Guid.NewGuid());

        var laboratoryWorkBuilder = new LaboratoryWorkBuilder();
        laboratoryWorkBuilder.WithAuthor(author);
        laboratoryWorkBuilder.WithName("lab1");
        laboratoryWorkBuilder.WithId(Guid.NewGuid());
        laboratoryWorkBuilder.WithPointsAmount(new Points(100));
        laboratoryWorkBuilder.WithDescription("some description");
        laboratoryWorkBuilder.WithCurrentUser(author);

        ILaboratoryWork laboratoryWork = laboratoryWorkBuilder.Build();

        var examSubjectBuilder = new ExamSubjectBuilder();
        examSubjectBuilder.WithAuthor(author);
        examSubjectBuilder.WithName("lab1");
        examSubjectBuilder.WithId(originalId);
        examSubjectBuilder.WithPoints(new Points(10));
        examSubjectBuilder.AddLaboratoryWork(laboratoryWork);
        examSubjectBuilder.WithCurrentUser(author);

        var examSubject = (ISubject<ExamSubject>)examSubjectBuilder.Build();

        var testSubjectBuilder = new TestSubjectBuilder();
        testSubjectBuilder.WithAuthor(author);
        testSubjectBuilder.WithName("lab1");
        testSubjectBuilder.WithId(originalId);
        testSubjectBuilder.WithMinSuccessPoints(new Points(10));
        testSubjectBuilder.AddLaboratoryWork(laboratoryWork);
        testSubjectBuilder.WithCurrentUser(author);

        var testSubject = (ISubject<TestSubject>)testSubjectBuilder.Build();

        // Act
        ISubject clonedSubjectWithNewId = examSubject.Clone(Guid.NewGuid());
        ISubject clonedSubjectWithNewId2 = testSubject.Clone(Guid.NewGuid());

        // Assert
        Assert.NotEqual(examSubject.Id, clonedSubjectWithNewId.Id);
        Assert.Equal(examSubject.Id, clonedSubjectWithNewId.ParentId);

        Assert.NotEqual(testSubject.Id, clonedSubjectWithNewId2.Id);
        Assert.Equal(testSubject.Id, clonedSubjectWithNewId2.ParentId);

        Assert.Throws<ArgumentException>(() => examSubject.Clone(originalId));
        Assert.Throws<ArgumentException>(() => testSubject.Clone(originalId));
    }

    [Fact]
    public void CreatingSubjects_ShouldThrow_WhenPointsAreNotEqualsToMaxSubjectPoints()
    {
        // Arrange
        var author = new User("ssnchk", Guid.NewGuid());

        var laboratoryWorkBuilder = new LaboratoryWorkBuilder();
        laboratoryWorkBuilder.WithAuthor(author);
        laboratoryWorkBuilder.WithName("lab1");
        laboratoryWorkBuilder.WithId(Guid.NewGuid());
        laboratoryWorkBuilder.WithPointsAmount(new Points(1));
        laboratoryWorkBuilder.WithDescription("some description");
        laboratoryWorkBuilder.WithCurrentUser(author);

        ILaboratoryWork laboratoryWork = laboratoryWorkBuilder.Build();

        var examSubjectBuilder = new ExamSubjectBuilder();
        examSubjectBuilder.WithAuthor(author);
        examSubjectBuilder.WithName("lab1");
        examSubjectBuilder.WithId(Guid.NewGuid());
        examSubjectBuilder.WithPoints(new Points(10));
        examSubjectBuilder.AddLaboratoryWork(laboratoryWork);
        examSubjectBuilder.WithCurrentUser(author);

        var testSubjectBuilder = new TestSubjectBuilder();
        testSubjectBuilder.WithAuthor(author);
        testSubjectBuilder.WithName("lab1");
        testSubjectBuilder.WithId(Guid.NewGuid());
        testSubjectBuilder.WithMinSuccessPoints(new Points(10));
        testSubjectBuilder.AddLaboratoryWork(laboratoryWork);
        testSubjectBuilder.WithCurrentUser(author);

        // Act
        Assert.Throws<ArgumentException>(() => examSubjectBuilder.Build());
        Assert.Throws<ArgumentException>(() => testSubjectBuilder.Build());
    }
}