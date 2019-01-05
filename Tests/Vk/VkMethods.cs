using System.Threading.Tasks;
using Vk;
using Xunit;

namespace Tests.Vk
{
    public class VkMethods
    {
        [Fact]
        public async Task GetUsername_Valid_String()
        {
            var result = await Users.GetUserName(1);
            Assert.False(string.IsNullOrEmpty(result));
        }

        [Fact]
        public async Task GetUsername_NotValid_EmptyString()
        {
            var result = await Users.GetUserName(0);
            Assert.True(string.IsNullOrEmpty(result));
        }

        [Fact]
        public async Task SendMessage_Correct()
        {
            await Messages.Send(157312383, "test", new[] {"photo-146048760_456239017"});
            await Messages.Send(new long[] { 157312383, 366305213 }, "test",
                new[] { "photo-146048760_456239017" });
        }
    }
}
