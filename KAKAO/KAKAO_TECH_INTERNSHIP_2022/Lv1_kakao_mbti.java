package kakao_tech_internship_2022;

public class Lv1_kakao_mbti {

    public static final int R = 0;
    public static final int T = 1;
    public static final int C = 2;
    public static final int F = 3;
    public static final int J = 4;
    public static final int M = 5;
    public static final int A = 6;
    public static final int N = 7;

    public static int[] score = {0, 3, 2, 1, 0, 1, 2, 3};

    // 0:R, 1:T, C:2, F:3, J:4, M:5, A:6, N:7
    public static int[] mbti = new int[8];

    public static void main(String[] args) {

//        String[] survey = {"AN", "CF", "MJ", "RT", "NA"};
//        int[] choices = {5, 3, 2, 7, 5};

        String[] survey = {"TR", "RT", "TR"};
        int[] choices = {7, 1, 3};

        System.out.println(solution(survey, choices));
    }

    public static String solution(String[] survey, int[] choices) {

        for (int i = 0; i < survey.length; i++) {
            Character disagree = survey[i].charAt(0);
            Character agree = survey[i].charAt(1);

            int ansNum = choices[i];
            if (ansNum > 4) {   // agree
                plusScore(agree, ansNum);
            } else if (ansNum < 4) {    // disagree
                plusScore(disagree, ansNum);
            }
        }

        String answer = "";

        if (mbti[R] >= mbti[T]) answer += "R";
        else answer += "T";
        if (mbti[C] >= mbti[F]) answer += "C";
        else answer += "F";
        if (mbti[J] >= mbti[M]) answer += "J";
        else answer += "M";
        if (mbti[A] >= mbti[N]) answer += "A";
        else answer += "N";

        return answer;
    }

    public static void plusScore(Character c, int ansNum) {

        switch (c) {
            case 'R': mbti[R] += score[ansNum]; break;
            case 'T': mbti[T] += score[ansNum]; break;
            case 'C': mbti[C] += score[ansNum]; break;
            case 'F': mbti[F] += score[ansNum]; break;
            case 'J': mbti[J] += score[ansNum]; break;
            case 'M': mbti[M] += score[ansNum]; break;
            case 'A': mbti[A] += score[ansNum]; break;
            case 'N': mbti[N] += score[ansNum]; break;
        }
    }
}
