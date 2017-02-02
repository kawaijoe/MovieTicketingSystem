using MovieTicketingSystem.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu.commands {

    // Command Pattern Implementation
    interface Command {
        void execute(OptionAttempt attempt);
    }
}
