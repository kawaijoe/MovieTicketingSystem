using System;

namespace MovieTicketingSystem.util {
    class FailedConversionException:Exception {

        public FailedConversionException():base("Tryconverting failed to convert values!") { }

        public FailedConversionException(String message):base(message) { }
    }
}
