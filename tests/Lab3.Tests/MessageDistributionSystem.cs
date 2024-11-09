using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.FilteredAddressees;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.LoggingAddressees;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using NSubstitute;
using Xunit;

namespace Lab3.Tests;

public class MessageDistributionSystem
{
    [Fact]
    public void WhenUserReceiveMessageItShouldBeUnread()
    {
        // Arrange
        var message1 = new Message("Title1", "Body1", 1);
        var message2 = new Message("Title2", "Body2", 2);
        var message3 = new Message("Title3", "Body3", 3);

        var user = new User();

        var addressee = new AddresseeUser(user);

        // Act
        addressee.ReceiveMessage(message1);
        addressee.ReceiveMessage(message2);
        addressee.ReceiveMessage(message3);

        // Assert
        foreach (MessageStatus status in user.Messages.Values)
        {
            Assert.False(status.IsRead);
        }
    }

    [Fact]
    public void WhenUserReceiveMessageAndMarkItAsReadItShouldBeRead()
    {
        // Arrange
        var message1 = new Message("Title1", "Body1", 1);
        var message2 = new Message("Title2", "Body2", 2);
        var message3 = new Message("Title3", "Body3", 3);

        var user = new User();

        var addressee = new AddresseeUser(user);

        // Act
        addressee.ReceiveMessage(message1);
        addressee.ReceiveMessage(message2);
        addressee.ReceiveMessage(message3);

        foreach (MessageStatus status in user.Messages.Values)
        {
            status.MarkAsRead();
        }

        // Assert
        foreach (MessageStatus status in user.Messages.Values)
        {
            Assert.True(status.IsRead);
        }
    }

    [Fact]
    public void WhenUserUserMarkReadMessageAsReadItShouldReturnFail()
    {
        // Arrange
        var message1 = new Message("Title1", "Body1", 1);
        var message2 = new Message("Title2", "Body2", 2);
        var message3 = new Message("Title3", "Body3", 3);

        var user = new User();

        var addressee = new AddresseeUser(user);

        // Act
        addressee.ReceiveMessage(message1);
        addressee.ReceiveMessage(message2);
        addressee.ReceiveMessage(message3);

        foreach (MessageStatus status in user.Messages.Values)
        {
            status.MarkAsRead();
        }

        // Assert
        foreach (MessageStatus status in user.Messages.Values)
        {
            Assert.IsType<MarkAsReadResult.Failure>(status.MarkAsRead());
        }
    }

    [Fact]
    public void FilteredAddresseeShouldNotReceiveUnfilteredMessage()
    {
        // Arrange
        var message1 = new Message("Title1", "Body1", 1);
        var message2 = new Message("Title2", "Body2", 2);
        var message3 = new Message("Title3", "Body3", 3);

        IUser mockUser = Substitute.For<IUser>();

        var addressee = new AddresseeUser(mockUser);
        var filteredAddressee = new FilteredAddressee(addressee, (a) => a == 1);

        // Act
        filteredAddressee.ReceiveMessage(message1);
        filteredAddressee.ReceiveMessage(message2);
        filteredAddressee.ReceiveMessage(message3);

        // Assert
        mockUser.Received(1).ReceiveMessage(Arg.Any<Message>());
    }

    [Fact]
    public void LoggedAddresseeShouldLogReceivedMessage()
    {
        // Arrange
        var message1 = new Message("Title1", "Body1", 1);
        var message2 = new Message("Title2", "Body2", 2);
        var message3 = new Message("Title3", "Body3", 3);

        ILogger mockLogger = Substitute.For<ILogger>();

        var user = new User();
        var addressee = new AddresseeUser(user);
        var loggingAddressee = new LoggingAddressee(addressee, mockLogger);

        // Act
        loggingAddressee.ReceiveMessage(message1);
        loggingAddressee.ReceiveMessage(message2);
        loggingAddressee.ReceiveMessage(message3);

        // Assert
        mockLogger.Received(3).Log(Arg.Any<string>(), Arg.Any<int>());
    }

    [Fact]
    public void MessengerShouldReceiveMessage()
    {
        // Arrange
        var message1 = new Message("Title1", "Body1", 1);
        var message2 = new Message("Title2", "Body2", 2);
        var message3 = new Message("Title3", "Body3", 3);

        IMessenger mockMessenger = Substitute.For<IMessenger>();

        var addressee = new AddresseeMessenger(mockMessenger);

        // Act
        addressee.ReceiveMessage(message1);
        addressee.ReceiveMessage(message2);
        addressee.ReceiveMessage(message3);

        // Assert
        mockMessenger.Received(3).ReceiveMessage(Arg.Any<Message>());
    }

    [Fact]
    public void WhenTopicHasOneFilteredAddresseeAndOneUnfilteredAddresseeItShouldReceiveOneMessage()
    {
        // Arrange
        var message = new Message("Title1", "Body1", 1);

        IUser mockUser = Substitute.For<IUser>();

        var addressee = new AddresseeUser(mockUser);
        var filteredAddressee = new FilteredAddressee(addressee, (a) => a == 0);

        var topic = new Topic("Topic");

        topic.AddAddressee(addressee);
        topic.AddAddressee(filteredAddressee);

        // Act
        topic.SendMessage(message);

        // Assert
        mockUser.Received(1).ReceiveMessage(Arg.Any<Message>());
    }
}