﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroProject.Room
{
    public interface IRoomController
    {
        Action GoToNextRoom { get; set; }
        Action GoToPreviousRoom { get; set; }
        void ShowStage();
        void HideStage();
    }
}
