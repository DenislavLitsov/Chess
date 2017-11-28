namespace FrontEndEngine.Chess.Classes.MovementStrategies.ConditionalMovements
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class Conditions : Condition
    {
        private List<Condition> _Conditions;
        
        public Conditions(List<Condition> conditions)
        {
            this._Conditions = conditions;
        }

        public List<Condition> GetConditions()
        {
            return this._Conditions;
        }

        public Condition GetCondition(Type cond)
        {
            foreach (var item in this._Conditions)
            {
                if (item.GetType() == cond)
                {
                    return item;
                }
            }

            return null;
        }

        public override bool IsConditionFulfilled(Move move, Board.Board board)
        {
            for (int i = 0; i < _Conditions.Count; i++)
            {
                if (this._Conditions[i].IsConditionFulfilled(move, board) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}