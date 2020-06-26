namespace ParkingPrint
{
    /// <summary>
    /// 한글 헬퍼
    /// </summary>
    public class HangulHelper
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region Field

        /// <summary>
        /// 초성 수
        /// </summary>
        private const int INITIAL_COUNT = 19;

        /// <summary>
        /// 중성 수
        /// </summary>
        private const int MEDIAL_COUNT = 21;

        /// <summary>
        /// 종성 수
        /// </summary>
        private const int FINAL_COUNT = 28;

        /// <summary>
        /// 한글 유니코드 시작 인덱스
        /// </summary>
        private const int HANGUL_UNICODE_START_INDEX = 0xac00;

        /// <summary>
        /// 한글 유니코드 종료 인덱스
        /// </summary>
        private const int HANGUL_UNICODE_END_INDEX = 0xD7A3;

        /// <summary>
        /// 초성 시작 인덱스
        /// </summary>
        private const int INITIAL_START_INDEX = 0x1100;

        /// <summary>
        /// 중성 시작 인덱스
        /// </summary>
        private const int MEDIAL_START_INDEX = 0x1161;

        /// <summary>
        /// 종성 시작 인덱스
        /// </summary>
        private const int FINAL_START_INDEX = 0x11a7;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Static
        //////////////////////////////////////////////////////////////////////////////// Public

        #region 한글 여부 구하기 - IsHangul(char source)

        /// <summary>
        /// 한글 여부 구하기
        /// </summary>
        /// <param name="source">소스 문자</param>
        /// <returns>한글 여부</returns>
        public static bool IsHangul(char source)
        {
            if(HANGUL_UNICODE_START_INDEX <= source && source <= HANGUL_UNICODE_END_INDEX)
            {
                return true;
            }

            return false;
        }

        #endregion
        #region 한글 여부 구하기 - IsHangul(string source)

        /// <summary>
        /// 한글 여부 구하기
        /// </summary>
        /// <param name="source">소스 문자열</param>
        /// <returns>한글 여부</returns>
        public static bool IsHangul(string source)
        {
            bool result = false;

            for(int i = 0; i < source.Length; i++)
            {
                if(HANGUL_UNICODE_START_INDEX <= source[i] && source[i] <= HANGUL_UNICODE_END_INDEX)
                {
                    result = true;
                }
                else
                {
                    result = false;

                    break;
                }
            }

            return result;
        }

        #endregion
        #region 한글 나누기 - DivideHangul(source)

        /// <summary>
        /// 한글 나누기
        /// </summary>
        /// <param name="source">소스 한글 문자</param>
        /// <returns>분리된 자소 배열</returns>
        public static char[] DivideHangul(char source)
        {
            char[] elementArray = null;

            if(IsHangul(source))
            {
                int index = source - HANGUL_UNICODE_START_INDEX;

                int initial = INITIAL_START_INDEX +  index / (MEDIAL_COUNT * FINAL_COUNT);
                int medial  = MEDIAL_START_INDEX  + (index % (MEDIAL_COUNT * FINAL_COUNT)) / FINAL_COUNT;
                int final   = FINAL_START_INDEX   +  index % FINAL_COUNT;

                if(final == 4519)
                {
                    elementArray = new char[2];

                    elementArray[0] = (char)initial;
                    elementArray[1] = (char)medial;
                }
                else
                {
                    elementArray = new char[3];

                    elementArray[0] = (char)initial;
                    elementArray[1] = (char)medial;
                    elementArray[2] = (char)final;
                }
            }

            return elementArray;
        }

        #endregion
    }
}