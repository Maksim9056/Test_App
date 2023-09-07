
using Server_Test_Users;
namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Program program = new Program();
        // Arrange
    

            // Act
            int result = program.Add(2, 3);

            // Assert
            Assert.Equal(5, result);
          //  Console.ReadLine();
        }
    }
}