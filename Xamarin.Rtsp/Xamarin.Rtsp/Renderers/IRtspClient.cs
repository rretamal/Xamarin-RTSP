using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Rtsp.Renderers
{
    public interface IRtspClient<T>
    {
        Task<bool> StartStreaming(T customView);
    }
}
