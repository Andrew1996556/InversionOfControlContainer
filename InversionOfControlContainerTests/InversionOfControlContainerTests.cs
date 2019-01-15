using System;
using InversionOfControlContainer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IoCContainer.Tests
{
    [TestClass]
    public class IoCContainerTests
    {
        [TestMethod]
        public void Registration_creadNewObject_NotNull()
        {
            var c = new ContainerBuilder();
            c.Register<IWeapon, Weapon>()
               .AddConstructionArgument("name", "qwerty")
                    .AddConstructionArgument("bulka", true)
                    .AddConstructionArgument("lenght", 15);
            var actual = c.GetService<IWeapon>();
            Assert.IsNotNull(actual);
        }


        [TestMethod]
        public void RegisterSingltone_EqealsObject_False()
        {
            var c = new ContainerBuilder();
            c.RegisterSingltone<IWeapon, Weapon>()
                .AddConstructionArgument("name", "qwerty")
                     .AddConstructionArgument("bulka", true)
                     .AddConstructionArgument("lenght", 15);

            var weaponOne = c.GetService<IWeapon>();
            var weaponTwo = c.GetService<IWeapon>();

            Assert.AreNotEqual(weaponOne, weaponTwo);
        }

        [TestMethod]
        public void Register_EqealsObject_False()
        {
            var c = new ContainerBuilder();
            c.Register<IWeapon, Weapon>().AddConstructionArgument("name", "qwerty")
                     .AddConstructionArgument("bulka", true)
                     .AddConstructionArgument("lenght", 15);


            var weaponOne = c.GetService<IWeapon>();
            var weaponTwo = c.GetService<IWeapon>();

            Assert.AreNotEqual(weaponOne, weaponTwo);
        }

        [TestMethod]
        public void Registration_СheckOnResistration_ExceptionTrue()
        {
            try
            {
                var c = new ContainerBuilder();
                c.Register<IWeapon, Weapon>()
                .AddConstructionArgument("name", "qwerty")
                     .AddConstructionArgument("bulka", true)
                     .AddConstructionArgument("lenght", 15);
                c.Register<IWeapon, Weapon>()
                .AddConstructionArgument("name", "qwerty")
                     .AddConstructionArgument("bulka", true)
                     .AddConstructionArgument("lenght", 15);

                Assert.Fail("Don't was exception");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Equals(ex));
            }
        }

        [TestMethod]
        public void RegistrationTwoInterface_СheckOnResistration_ExceptionTrue()
        {
            try
            {
                var c = new ContainerBuilder();
                c.Register<IWeapon, IWeapon>();

                Assert.Fail("Don't was exception");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Equals(ex));
            }
        }

        [TestMethod]
        public void RegistrationTwoClass_СheckOnResistration_ExceptionTrue()
        {
            try
            {
                var c = new ContainerBuilder();
                c.Register<Weapon, Weapon>();

                Assert.Fail("Don't was exception");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Equals(ex));
            }
        }
    }
}
