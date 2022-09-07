
// 2022 카카오 블라인드 채용

public class Lv2_archery_competition {

    private static final int ARRAY_LENGTH = 11;
    public static int[] resultScore = {-1};
    public static int[] lionScoreInfo;

    public static int maxScoreDiff = 0;

    public static void main(String[] args) {

//        int n = 5;
//        int[] info = {2,1,1,1,0,0,0,0,0,0,0};

        int n = 1;
        int[] info = {1,0,0,0,0,0,0,0,0,0,0};

        int[] answer = solution(n, info);
        for (int i = 0; i < answer.length; i++) {
            System.out.println(answer[i]);
        }
    }

    public static int[] solution(int n, int[] info) {

        lionScoreInfo = new int[ARRAY_LENGTH];

        playGame(0, n, info);
        int[] answer = resultScore;
        return answer;
    }

    public static void playGame(int curArrowNum, int arrowNum, int[] apeachScoreInfo) {

        if (curArrowNum == arrowNum) {
            int curScoreDiff = calculateScoreDiff(lionScoreInfo, apeachScoreInfo);
            if (maxScoreDiff <= curScoreDiff) {
                resultScore = lionScoreInfo.clone();
                maxScoreDiff = curScoreDiff;
            }
            return;
        }

        for (int i = 0; i <= 10 && lionScoreInfo[i] <= apeachScoreInfo[i]; i++) {
            lionScoreInfo[i]++;
            playGame(curArrowNum+1, arrowNum, apeachScoreInfo);
            lionScoreInfo[i]--;
        }
    }

    public static int calculateScoreDiff(int[] lionScoreInfo, int[] apeachScoreInfo) {

        int lionScore = 0, apeachScore = 0;

        for (int i = 0; i < ARRAY_LENGTH; i++) {
            if (lionScoreInfo[i] > apeachScoreInfo[i]) {
                lionScore += (10 - i);
            } else if (apeachScoreInfo[i] != 0){
                apeachScore += (10 - i);
            }
        }

        if (lionScore > apeachScore) return lionScore - apeachScore;
        else return -1;
    }
}
