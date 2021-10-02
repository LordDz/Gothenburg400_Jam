using Assets._Game.Scripts.Levels;
using Assets._Game.Scripts.UI;
using RPGM.Core;
using UnityEngine;

namespace RPGM.Gameplay
{
    /// <summary>
    /// Main class for implementing NPC game objects.
    /// </summary>
    public class NPCController : MonoBehaviour
    {
        public ConversationScript[] conversations;
        private bool hasTalked = false;

        Quest activeQuest = null;

        Quest[] quests;

        GameModel model = Schedule.GetModel<GameModel>();

        CharacterController2D plr;

        private float talkDistance = 1.6f;
        public InventoryItem inventoryItem;

        private NPCTalkInteract NPCTalkInteract;

        void OnEnable()
        {
            plr = FindObjectOfType<CharacterController2D>();
            quests = gameObject.GetComponentsInChildren<Quest>();
            NPCTalkInteract = GetComponentInChildren<NPCTalkInteract>();
        }

        public bool IsWithinDistance()
        {
            return Vector2.Distance(transform.position, plr.transform.position) <= talkDistance;
        }

        public void SwitchToNextScene()
        {
            if (IsWithinDistance())
            {
                SceneSwitcher sceneSwitcher = FindObjectOfType<SceneSwitcher>();
                sceneSwitcher.SwitchToNextScene();
            }
        }

        public void TalkToFromItem(bool allowRepeat = false)
        {
            if (hasTalked)
            {
                return;
            }

            if (!allowRepeat)
            {
                hasTalked = true;

                if (NPCTalkInteract)
                {
                    NPCTalkInteract.SetHasTalked();
                }
            }

            var c = GetConversation();
            if (c != null)
            {
                var ev = Schedule.Add<Events.ShowConversation>();
                ev.conversation = c;
                ev.npc = this;
                ev.gameObject = gameObject;
                ev.conversationItemKey = "";
            }
        }

        public void TalkTo()
        {
            if (hasTalked || !IsWithinDistance())
            {
                return;
            }

            if (inventoryItem)
            {
                inventoryItem.PickupItem();
            }

            hasTalked = true;
            if (NPCTalkInteract)
            {
                NPCTalkInteract.SetHasTalked();
            }

            var c = GetConversation();
            if (c != null)
            {
                var ev = Schedule.Add<Events.ShowConversation>();
                ev.conversation = c;
                ev.npc = this;
                ev.gameObject = gameObject;
                ev.conversationItemKey = "";
            }
        }

        public void CompleteQuest(Quest q)
        {
            if (activeQuest != q) throw new System.Exception("Completed quest is not the active quest.");
            foreach (var i in activeQuest.requiredItems)
            {
                model.RemoveInventoryItem(i.item, i.count);
            }
            activeQuest.RewardItemsToPlayer();
            activeQuest.OnFinishQuest();
            activeQuest = null;
        }

        public void StartQuest(Quest q)
        {
            if (activeQuest != null) throw new System.Exception("Only one quest should be active.");
            activeQuest = q;
        }

        ConversationScript GetConversation()
        {
            if (conversations.Length == 0)
            {
                return null;
            }

            if (activeQuest == null)
            {
                return conversations[0];
            }
            foreach (var q in quests)
            {
                if (q == activeQuest)
                {
                    if (q.IsQuestComplete())
                    {
                        CompleteQuest(q);
                        return q.questCompletedConversation;
                    }
                    return q.questInProgressConversation;
                }
            }
            return null;
        }
    }
}
