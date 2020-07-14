
using System.Collections.Generic;

namespace JogoGourmet.Models
{
    class QuestionTree
    {
        public QuestionTree(string questionParam, string yesAnswer, string noAnswer)
        {
            this.nodesYes = new List<QuestionTree>();
            this.nodesNo = new List<QuestionTree>();
            this.questionParam = questionParam;
            this.yesAnswer = yesAnswer;
            this.noAnswer = noAnswer;
        }

        public List<QuestionTree> nodesYes;
        public List<QuestionTree> nodesNo;
        private string questionParam;
        private string yesAnswer;
        private string noAnswer;

        public string QuestionParam
        {
            get { return questionParam; }
            set { questionParam = value; }
        }
        public string YesAnswer
        {
            get { return yesAnswer; }
            set { yesAnswer = value; }
        }

        public string NoAnswer
        {
            get { return noAnswer; }
            set { noAnswer = value; }
        }
    }
}
