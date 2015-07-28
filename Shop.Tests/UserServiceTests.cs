﻿using FluentAssertions;
using NSubstitute;
using Ploeh.AutoFixture.Xunit;
using Shop.Domain;
using Xunit.Extensions;

namespace Shop.Tests
{
    public class UserServiceTests
    {
        [Theory]
        [ShopAutoData]
        public void register_nonexisting_user_invoke_repository_create_user(
            [Frozen]IUserRepository repo,
            UserService sut,
            UserModel newUser)
        {
            repo.UserExists(newUser.Login)
                .Returns(false);

            sut.RegisterUser(newUser);
            
            repo.Received()
                .CreateUser(newUser);
        }

        [Theory]
        [ShopAutoData]
        public void register_user_invoke_repository_user_exists(
            [Frozen]IUserRepository repo,
            UserService sut,
            UserModel newUser)
        {
            sut.RegisterUser(newUser);

            repo.Received()
                .UserExists(newUser.Login);
        }

        [Theory]
        [ShopAutoData]
        public void register_user_should_return_status_ok(
            [Frozen] IUserRepository repo,
            UserService sut,
            UserModel newUser)
        {
            repo.UserExists(newUser.Login)
                .Returns(false);

            sut.RegisterUser(newUser)
                .ShouldBeEquivalentTo(ServiceStatus.Ok);
        }

        [Theory, ShopAutoData]
        public void register_existing_user_should_return_conflict(
            [Frozen] IUserRepository repo,
            UserService sut,
            UserModel newUser)
        {
            repo.UserExists(newUser.Login)
                .Returns(true);

            sut.RegisterUser(newUser)
                .Should()
                .Be(ServiceStatus.Conflict);
        }
    }
}
