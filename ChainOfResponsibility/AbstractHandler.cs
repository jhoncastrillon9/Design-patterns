using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    // El comportamiento de encadenamiento predeterminado se puede implementar dentro de un controlador base
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;


            // Devolver un controlador desde aquí nos permitirá vincular los controladores en un
            // forma conveniente como esta:
            // mono.SetNext (ardilla) .SetNext (perro);
            return handler;
        }

        public virtual object Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }
}
