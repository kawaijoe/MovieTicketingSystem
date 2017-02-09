using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.util {
    class FailedConversionException:Exception {

        public FailedConversionException():base("Tryconverting failed to convert values!") { }

        public FailedConversionException(String message):base(message) { }
    }
}
