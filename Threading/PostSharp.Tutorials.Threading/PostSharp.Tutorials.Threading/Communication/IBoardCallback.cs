﻿using System;
using System.ServiceModel;

namespace PostSharp.Tutorials.Threading.Communication
{
    public interface IBoardCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnCreatureMoved(Guid id, double x, double y);

        [OperationContract(IsOneWay = true)]
        void OnCreatureRotated(Guid id, double orientation);

        [OperationContract(IsOneWay = true)]
        void OnCreatureCreated( Creature creature );
    }
}
