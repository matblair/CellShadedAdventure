﻿using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brace.PhysicsEngine
{
    public class PhysicsModel
    {
        public PhysicsBody bodyDefinition;
        public float invmass;
        public Vector3 velocity;
        public Vector3 forces;
        public Vector3 position;
        public Vector3 location;
        public List<Contact> contacts;
        
    }
}
