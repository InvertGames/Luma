using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;


public class PlayerSystem : PlayerSystemBase {
    protected override void ComponentCreated(IEvent e)
    {
        base.ComponentCreated(e);
        var playerComponent = e.Data as Player;
        if (playerComponent != null)
        {
            SignalPlayerLoaded(new PlayerEventData()
            {
                PlayerData = playerComponent,
                PlayerId = playerComponent.EntityId
            });

            
            foreach (var player in this.PlayerManager.Components)
            {
                foreach (var item in ActiveWithXpManager.Components)
                {
                    item.gameObject.SetActive(item.RequiredXp <= player.XP);
                }
            }

        }
    }

    protected override void PlayerXpChanged(IEvent e)
    {
        base.PlayerXpChanged(e);
        foreach (var player in this.PlayerManager.Components)
        {
            foreach (var item in ActiveWithXpManager.Components)
            {
                item.gameObject.SetActive(item.RequiredXp <= player.XP);
            }
        }

    }

    protected override void HandleAddXp(PlayerExperienceData data, Player player)
    {
        base.HandleAddXp(data, player);
        player.XP += data.XP;
        SignalPlayerXpChanged(new PlayerExperienceData()
        {
            PlayerId = player.EntityId,
            XP = player.XP
        });
    }
}
