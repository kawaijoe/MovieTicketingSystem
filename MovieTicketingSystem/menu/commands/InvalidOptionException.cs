using System;

namespace MovieTicketingSystem.menu.commands {
    class InvalidOptionException:Exception {

        public InvalidOptionException():base("User has entered an invalid option for the maximum amount of retries.") { }

        public InvalidOptionException(String message):base(message) { }
    }
}
