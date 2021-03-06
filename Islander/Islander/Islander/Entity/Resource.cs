﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Islander.Entity
{
    class Resource : Entity
    {
        public Colour Colour { get; protected set; }
        public bool IsCarried { get; set; }
        public Island.IslandType islandType;

        static Dictionary<Island.IslandType, string> resources = new Dictionary<Island.IslandType, string>()
        {
            {Island.IslandType.Bubble, "BlueCargo"},
            {Island.IslandType.Fantasy, "BlueCargo"},
            {Island.IslandType.Razor, "YellowCargo"},
            {Island.IslandType.Treasure, "YellowCargo"},
            {Island.IslandType.Love, "RedCargo"},
            {Island.IslandType.Trident, "RedCargo"},
            {Island.IslandType.Hermit, "GreenCargo"},
            {Island.IslandType.Magnet, "GreenCargo"},
        };

        public Resource(Texture2D sprite, Colour colour, Island.IslandType islandType) : base(sprite)
        {
            Colour = colour;
            scale = new Vector2(0.3f);
            IsCarried = false;

            this.islandType = islandType;
            Debug.WriteLine("Resource Island Type = " + islandType);
        }

        // Create a copy from this resource
        public Resource(Resource resource) : base(resource.sprite)
        {
            Colour = resource.Colour;
            scale = resource.scale;
            IsCarried = resource.IsCarried;
            islandType = resource.islandType;
        }

        // creates a new boat matching the specified colour, loading the sprite from the contentmanager
        public static Resource InitializeFromIslandType(Colour colour, Island.IslandType islandType, ContentManager content)
        {
            // retrieve texture name matching specified colour
            string textureName = resources[islandType];

            // load the texture specified from a folder named Resources
            Texture2D sprite = content.Load<Texture2D>("Cargo/" + textureName);

            // create a new entity using the loaded sprite
            return new Resource(sprite, colour, islandType);
        }

        public void SetRotation(float rotation)
        {
            this.rotation = rotation;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }
    }
}
