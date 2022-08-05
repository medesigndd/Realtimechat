using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SocketIOClient;

namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {



           // var processStages = new List<string> { "Starting", "Preparing", "Running", "Testing", "Cleaning", "Deploying", "Process Completed" };
            var processStages = new List<string> { "Citizen ID"};

            foreach (var p in processStages)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                SendProgress(p);
            }

            Console.Read();

        }



        public static async void SendProgress(string progress)
        {
            var client = new SocketIO("http://localhost:5555");
            await client.ConnectAsync();
            await client.EmitAsync("chatter", progress);


            await client.DisconnectAsync();

          //var dto = new TestDTO { Id = 123, Name = "bob" };

          //string content = "test socket";
          //await client.EmitAsync("privatemsg", "source", dto);

          //string name = "";

          //await client.EmitAsync("register", { name: "" + " connected"} );

          // socket.emit('sendName', { name: data.name + " connected"});

          //         socket.emit("private message", {
          //              content,
          //    to: this.selectedUser.userID,
          //  });


        }


    }
}


class TestDTO
{


    public int Id { get; set; }
    public String Name { get; set; }

}