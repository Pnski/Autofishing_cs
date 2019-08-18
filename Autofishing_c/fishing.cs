using System.Threading;
using System.Threading.Tasks;

class _fishing
{
    public static void init()
    {
        Task.Run(async () =>
        {
            while (true)
            {
                while (_ref.status == true)
                {
                    messaging.Send('5');
                    basket();
                    Thread.Sleep(500);
                }
                // don't run again for at least 200 milliseconds
                await Task.Delay(200);
            }
        });
    }

    static char basket()
    {
                    return '0';
      /*  mw.t_5 = 4;
        MainWindow.t_5.Text = 5;
        if (Autofishing_c.t_5.Text > 0)
        {
            return (char)5;
        }
        else if (int.Parse(Autofishing_c.MainWindow.t_6.Text) > 0)
        {
            return (char)6;
        }
        else if (int.Parse(Autofishing_c.MainWindow.t_7.Text) > 0)
        {
            return (char)7;
        }
        else if (int.Parse(Autofishing_c.MainWindow.t_8.Text) > 0)
        {
            return (char)8;
        }
        else
            _ref.status = false;
        return (char)0;*/
    }
}