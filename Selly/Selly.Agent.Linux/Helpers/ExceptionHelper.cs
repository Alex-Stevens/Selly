using System.IO;
using System.Text;

namespace Selly.Agent.Linux
{
    public class ExceptionHelper
    {
        public static void WriteFile(string name, string message)
        {
            using (FileStream file = new FileStream($@"/home/user/selly/Selly/Selly.Agent.Linux/{name}.txt", FileMode.Create))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(message);
                byte[] b = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
                file.Write(b, 0, b.Length);
            }
        }

        public static void WriteFile(System.Exception exception, string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(exception.Message);
            sb.AppendLine("\n\n");
            sb.AppendLine(exception.StackTrace);

            if (exception.InnerException != null)
            {
                sb.AppendLine("\n\n\n\n");
                sb.AppendLine(exception.InnerException.Message);
                sb.AppendLine("\n\n");
                sb.AppendLine(exception.InnerException.StackTrace);

                if (exception.InnerException.InnerException != null)
                {
                    sb.AppendLine("\n\n\n\n");
                    sb.AppendLine(exception.InnerException.InnerException.Message);
                    sb.AppendLine("\n\n");
                    sb.AppendLine(exception.InnerException.InnerException.StackTrace);
                }
            }

            WriteFile(name, sb.ToString());
        }
    }
}
