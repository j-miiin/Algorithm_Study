package kakao_tech_internship_2022;

import java.util.Arrays;

public class Lv3_coding_test_study {

    public static int[][] cost;
    public static int goal_alp = 0, goal_cop = 0;

    public static void main(String[] args) {

//        int alp = 10;
//        int cop = 10;
//        int[][] problems = {{10, 15, 2, 1, 2}, {20, 20, 3, 3, 4}};

        int alp = 0;
        int cop = 0;
        int[][] problems = {{0,0,2,1,2},{4, 5, 3, 1, 2}, {4, 11, 4, 0, 2},{10,4,0,4,2}};

        System.out.println(solution(alp, cop, problems));
    }

    public static int solution(int alp, int cop, int[][] problems) {

        for (int i = 0; i < problems.length; i++) {
            goal_alp = Math.max(goal_alp, problems[i][0]);
            goal_cop = Math.max(goal_cop, problems[i][1]);
        }

        if (alp > goal_alp) goal_alp = alp;
        if (cop > goal_cop) goal_cop = cop;

        cost = new int[goal_alp+2][goal_cop+2];
        for (int[] arr : cost) {
            Arrays.fill(arr, Integer.MAX_VALUE);
        }

        cost[alp][cop] = 0;
        for (int i = alp; i <= goal_alp; i++) {
            for (int j = cop; j <= goal_cop; j++) {
                cost[i+1][j] = Math.min(cost[i+1][j], cost[i][j] + 1);
                cost[i][j+1] = Math.min(cost[i][j+1], cost[i][j] + 1);
                updateCostWithProblems(problems, i, j);
            }
        }

        int answer = cost[goal_alp][goal_cop];
        return answer;
    }

    public static void updateCostWithProblems(int[][] problems, int curAlp, int curCop) {
        for (int i = 0; i < problems.length; i++) {
            int alp_req = problems[i][0];
            int cop_req = problems[i][1];
            int alp_rwd = problems[i][2];
            int cop_rwd = problems[i][3];
            int req_cost = problems[i][4];

            if (curAlp >= alp_req && curCop >= cop_req) {
                int nextAlp = curAlp + alp_rwd;
                int nextCop = curCop + cop_rwd;
                if (nextAlp > goal_alp) nextAlp = goal_alp;
                if (nextCop > goal_cop) nextCop = goal_cop;
                cost[nextAlp][nextCop] = Math.min(cost[nextAlp][nextCop], cost[curAlp][curCop] + req_cost);
            }
        }
    }
}
