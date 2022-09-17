package programmers;

// 프로그래머스 - 피로도
// https://school.programmers.co.kr/learn/courses/30/lessons/87946

public class fatigue_rate {

    public static int[][] dungeons_info;
    public static boolean[] visited;

    public static int result = -1;

    public static void main(String[] args) {
        int k = 80;
        int[][] dungeons = {{80, 20}, {50, 40}, {30, 10}};

        System.out.println(solution(k, dungeons));
    }

    public static int solution(int k, int[][] dungeons) {
        dungeons_info = dungeons;
        visited = new boolean[8];

        explore_dungeons(k, 0);

        int answer = result;
        return answer;
    }

    public static void explore_dungeons(int curFatigue, int count) {

        result = Math.max(result, count);

        for (int i = 0; i < dungeons_info.length; i++) {
            int cur_min_fatigue = dungeons_info[i][0];
            int cur_use_fatigue = dungeons_info[i][1];

            if (cur_min_fatigue > curFatigue) continue;

            if (!visited[i]) {
                visited[i] = true;
                explore_dungeons(curFatigue - cur_use_fatigue, count + 1);
                visited[i] = false;

            }
        }
    }
}
