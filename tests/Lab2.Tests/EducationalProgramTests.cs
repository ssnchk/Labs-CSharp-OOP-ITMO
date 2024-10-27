using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
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
        var author = new User("ssnchk");
        var notAuthor = new User("not_ssnchk");

        var laboratoryWorkBuilder = new LaboratoryWork.LaboratoryWorkBuilder();
        laboratoryWorkBuilder.WithAuthor(author);
        laboratoryWorkBuilder.WithName("lab1");
        laboratoryWorkBuilder.WithPointsAmount(new Points(10));
        laboratoryWorkBuilder.WithDescription("some description");
        laboratoryWorkBuilder.WithCurrentUser(author);

        ILaboratoryWork laboratoryWork = laboratoryWorkBuilder.Build();

        // Act
        UpdateLaboratoryWorkResult updateWithRightAuthor =
            laboratoryWork.Update("lab2", "some description", new Points(10), new List<string>());

        laboratoryWork.SetCurrentUser(notAuthor);

        UpdateLaboratoryWorkResult updateWithWrongAuthor =
            laboratoryWork.Update("lab2", "some description", new Points(10), new List<string>());

        // Assert
        Assert.IsType<UpdateLaboratoryWorkResult.Failure>(updateWithWrongAuthor);
        Assert.IsType<UpdateLaboratoryWorkResult.Success>(updateWithRightAuthor);
    }

    [Fact]
    public void ChangingLectureMaterial_ShouldReturn_Failure_WhenChangingNotByAuthor()
    {
        // Arrange
        var author = new User("ssnchk");
        var notAuthor = new User("not_ssnchk");

        var lectureMaterialBuilder = new LectureMaterial.LectureMaterialBuilder();
        lectureMaterialBuilder.WithAuthor(author);
        lectureMaterialBuilder.WithName("lab1");
        lectureMaterialBuilder.WithDescription("some description");
        lectureMaterialBuilder.WithContent("some context");
        lectureMaterialBuilder.WithCurrentUser(author);

        ILectureMaterial lectureMaterial = lectureMaterialBuilder.Build();

        // Act
        UpdateLectureMaterealResult updateWithRightAuthor = lectureMaterial.Update("name", "description", "content");

        lectureMaterial.SetCurrentUser(notAuthor);

        UpdateLectureMaterealResult setNameResultWithWrongAuthor = lectureMaterial.Update("name", "description", "content");

        // Assert
        Assert.IsType<UpdateLectureMaterealResult.Failure>(setNameResultWithWrongAuthor);
        Assert.IsType<UpdateLectureMaterealResult.Success>(updateWithRightAuthor);
    }

    [Fact]
    public void ChangingSubjects_ShouldReturn_Failure_WhenChangingNotByAuthor()
    {
        // Arrange
        var author = new User("ssnchk");
        var notAuthor = new User("not_ssnchk");

        var laboratoryWorkBuilder = new LaboratoryWork.LaboratoryWorkBuilder();
        laboratoryWorkBuilder.WithAuthor(author);
        laboratoryWorkBuilder.WithName("lab1");
        laboratoryWorkBuilder.WithPointsAmount(new Points(100));
        laboratoryWorkBuilder.WithDescription("some description");
        laboratoryWorkBuilder.WithCurrentUser(author);

        ILaboratoryWork laboratoryWork = laboratoryWorkBuilder.Build();

        var examSubjectBuilder = new ExamSubject.ExamSubjectBuilder(new Points(0));
        examSubjectBuilder.WithAuthor(author);
        examSubjectBuilder.WithName("lab1");
        examSubjectBuilder.AddLaboratoryWork(laboratoryWork);
        examSubjectBuilder.WithCurrentUser(author);

        ISubject examSubject = examSubjectBuilder.Build();

        var testSubjectBuilder = new TestSubject.TestSubjectBuilder(new Points(10));
        testSubjectBuilder.WithAuthor(author);
        testSubjectBuilder.WithName("lab1");
        testSubjectBuilder.AddLaboratoryWork(laboratoryWork);
        testSubjectBuilder.WithCurrentUser(author);

        ISubject testSubject = testSubjectBuilder.Build();

        // Act
        UpdateSubjectResult updateExamineSubjectWithRightAuthor = examSubject.Update("123");
        UpdateSubjectResult updateTestSubjectWithRightAuthor = testSubject.Update("23");

        examSubject.SetCurrentUser(notAuthor);
        testSubject.SetCurrentUser(notAuthor);

        UpdateSubjectResult updateExamineSubjectWithWrongAuthor = examSubject.Update("123");
        UpdateSubjectResult updateTestSubjectWithWrongAuthor = testSubject.Update("23");

        // Assert
        Assert.IsType<UpdateSubjectResult.Failure>(updateExamineSubjectWithWrongAuthor);
        Assert.IsType<UpdateSubjectResult.Success>(updateExamineSubjectWithRightAuthor);

        Assert.IsType<UpdateSubjectResult.Failure>(updateTestSubjectWithWrongAuthor);
        Assert.IsType<UpdateSubjectResult.Success>(updateTestSubjectWithRightAuthor);
    }

    [Fact]
    public void ClonedLaboratoryWork_ShouldHaveNewId_And_InitialId_And_Throw_WhenIdsAreEqual()
    {
        // Arrange
        var author = new User("ssnchk");

        var laboratoryWorkBuilder = new LaboratoryWork.LaboratoryWorkBuilder();
        laboratoryWorkBuilder.WithAuthor(author);
        laboratoryWorkBuilder.WithName("lab1");
        laboratoryWorkBuilder.WithPointsAmount(new Points(10));
        laboratoryWorkBuilder.WithDescription("some description");
        laboratoryWorkBuilder.WithCurrentUser(author);

        var laboratoryWork = (ILaboratoryWork<LaboratoryWork>)laboratoryWorkBuilder.Build();

        // Act
        ILaboratoryWork clonedLaboratoryWorkWithNewId =
            laboratoryWork.Clone();

        // Assert
        Assert.NotEqual(laboratoryWork.Id, clonedLaboratoryWorkWithNewId.Id);
        Assert.Equal(laboratoryWork.Id, clonedLaboratoryWorkWithNewId.ParentId);
    }

    [Fact]
    public void ClonedLectureMaterial_ShouldHaveNewId_And_InitialId_And_Throw_WhenIdsAreEqual()
    {
        // Arrange
        var author = new User("ssnchk");

        var lectureMaterialBuilder = new LectureMaterial.LectureMaterialBuilder();
        lectureMaterialBuilder.WithAuthor(author);
        lectureMaterialBuilder.WithName("lab1");
        lectureMaterialBuilder.WithDescription("some description");
        lectureMaterialBuilder.WithContent("some context");
        lectureMaterialBuilder.WithCurrentUser(author);

        var lectureMaterial = (ILectureMaterial<LectureMaterial>)lectureMaterialBuilder.Build();

        // Act
        ILectureMaterial clonedLectureMaterialWithNewId =
            lectureMaterial.Clone();

        // Assert
        Assert.NotEqual(lectureMaterial.Id, clonedLectureMaterialWithNewId.Id);
        Assert.Equal(lectureMaterial.Id, clonedLectureMaterialWithNewId.ParentId);
    }

    [Fact]
    public void ClonedSubject_ShouldHaveNewId_And_InitialId_And_Throw_WhenIdsAreEqual()
    {
        // Arrange
        var author = new User("ssnchk");

        var laboratoryWorkBuilder = new LaboratoryWork.LaboratoryWorkBuilder();
        laboratoryWorkBuilder.WithAuthor(author);
        laboratoryWorkBuilder.WithName("lab1");
        laboratoryWorkBuilder.WithPointsAmount(new Points(100));
        laboratoryWorkBuilder.WithDescription("some description");
        laboratoryWorkBuilder.WithCurrentUser(author);

        ILaboratoryWork laboratoryWork = laboratoryWorkBuilder.Build();

        var examSubjectBuilder = new ExamSubject.ExamSubjectBuilder(new Points(0));
        examSubjectBuilder.WithAuthor(author);
        examSubjectBuilder.WithName("lab1");
        examSubjectBuilder.AddLaboratoryWork(laboratoryWork);
        examSubjectBuilder.WithCurrentUser(author);

        var examSubject = (ISubject<ExamSubject>)examSubjectBuilder.Build();

        var testSubjectBuilder = new TestSubject.TestSubjectBuilder(new Points(10));
        testSubjectBuilder.WithAuthor(author);
        testSubjectBuilder.WithName("lab1");
        testSubjectBuilder.AddLaboratoryWork(laboratoryWork);
        testSubjectBuilder.WithCurrentUser(author);

        var testSubject = (ISubject<TestSubject>)testSubjectBuilder.Build();

        // Act
        ISubject clonedSubjectWithNewId = examSubject.Clone();
        ISubject clonedSubjectWithNewId2 = testSubject.Clone();

        // Assert
        Assert.NotEqual(examSubject.Id, clonedSubjectWithNewId.Id);
        Assert.Equal(examSubject.Id, clonedSubjectWithNewId.ParentId);

        Assert.NotEqual(testSubject.Id, clonedSubjectWithNewId2.Id);
        Assert.Equal(testSubject.Id, clonedSubjectWithNewId2.ParentId);
    }

    [Fact]
    public void CreatingSubjects_ShouldThrow_WhenPointsAreNotEqualsToMaxSubjectPoints()
    {
        // Arrange
        var author = new User("ssnchk");

        var laboratoryWorkBuilder = new LaboratoryWork.LaboratoryWorkBuilder();
        laboratoryWorkBuilder.WithAuthor(author);
        laboratoryWorkBuilder.WithName("lab1");
        laboratoryWorkBuilder.WithPointsAmount(new Points(1));
        laboratoryWorkBuilder.WithDescription("some description");
        laboratoryWorkBuilder.WithCurrentUser(author);

        ILaboratoryWork laboratoryWork = laboratoryWorkBuilder.Build();

        var examSubjectBuilder = new ExamSubject.ExamSubjectBuilder(new Points(10));
        examSubjectBuilder.WithAuthor(author);
        examSubjectBuilder.WithName("lab1");
        examSubjectBuilder.AddLaboratoryWork(laboratoryWork);
        examSubjectBuilder.WithCurrentUser(author);

        var testSubjectBuilder = new TestSubject.TestSubjectBuilder(new Points(12));
        testSubjectBuilder.WithAuthor(author);
        testSubjectBuilder.WithName("lab1");
        testSubjectBuilder.AddLaboratoryWork(laboratoryWork);
        testSubjectBuilder.WithCurrentUser(author);

        // Act
        Assert.Throws<ArgumentException>(() => examSubjectBuilder.Build());
        Assert.Throws<ArgumentException>(() => testSubjectBuilder.Build());
    }
}