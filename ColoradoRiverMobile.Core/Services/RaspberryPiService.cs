using System;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;

namespace ColoradoRiverMobile.Core.Services
{
    public class RaspberryPiService
    {
        private string host;
        private string username;
        private string password;

        public RaspberryPiService()
        {
            this.host = "192.168.0.102";
            this.username = "pi";
            this.password = "raspberry";
        }

        public void ConnectAndTurnOnDamGPIO(int GPIO) {

            try
            {
                using (SshClient c = new SshClient(host, username, password))
                {
                    StringBuilder navToFolder = new StringBuilder("cd /home/pi");
                    StringBuilder turnOnGPIOCmd = new StringBuilder("./LEDControllerOn.sh ");
                    turnOnGPIOCmd.Append(GPIO);

                    c.Connect();

                    SshCommand navigateToFolder = c.RunCommand(navToFolder.ToString());
                    SshCommand turnOnGPIO = c.RunCommand(turnOnGPIOCmd.ToString());

                    c.Disconnect();

                }
            }
            catch (Exception ex)
            {
                var message = "Failed to connect";
            }
        }
        public void ConnectAndTurnOffDamGPIO(int GPIO) {
            try
            {
                using (SshClient c = new SshClient(host, username, password)) {
                    StringBuilder navToFolder = new StringBuilder("cd /home/pi");
                    StringBuilder turnOffGPIOCmd = new StringBuilder("./LEDControllerOff.sh ");
                    turnOffGPIOCmd.Append(GPIO);

                    c.Connect();

                    SshCommand navigateToFolder = c.RunCommand(navToFolder.ToString());
                    SshCommand turnOffGPIO = c.RunCommand(turnOffGPIOCmd.ToString());

                    c.Disconnect();
                }
            }
            catch (Exception ex)
            {
                var message = "Failed to connect";
            }

        }

    }
}
