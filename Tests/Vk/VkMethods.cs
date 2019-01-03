using System.Threading.Tasks;
using Xunit;

namespace Tests.Vk
{
    public class VkMethods
    {
        [Fact]
        public async Task GetUsername_Valid_String()
        {
            var result = await Goblin.Vk.VkMethods.GetUserName(1);
            Assert.False(string.IsNullOrEmpty(result));
        }

        [Fact]
        public async Task GetUsername_NotValid_EmptyString()
        {
            var result = await Goblin.Vk.VkMethods.GetUserName(0);
            Assert.True(string.IsNullOrEmpty(result));
        }

        [Fact]
        public async Task SendMessage_Correct()
        {
            await Goblin.Vk.VkMethods.SendMessage(157312383, "test", new[] {"photo-146048760_456239017"});
            await Goblin.Vk.VkMethods.SendMessage(new long[] { 157312383, 366305213 }, "test",
                new[] { "photo-146048760_456239017" });
        }
    }
}
