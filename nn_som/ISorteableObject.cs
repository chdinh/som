using System;
using System.Collections.Generic;
using System.Text;

namespace nn_som
{
    public interface ISorteableObject
    {
        bool CompareTo(ISorteableObject a);
    }
}
