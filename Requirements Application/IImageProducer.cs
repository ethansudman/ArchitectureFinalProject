using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Requirements_Application
{
    public interface IImageProducer
    {
        string ImagePath { get; }

        byte[] Image { get; }

        string Extension { get; }

        // todo add enum

        /// <summary>
        /// If a UML tool has to generate an image manually (e.g. in NClass you have to explicitly convert to an image)
        /// </summary>
        /// <returns><c>true</c> if successful; <c>false</c> otherwise</returns>
        bool ProduceImage();
    }
}
