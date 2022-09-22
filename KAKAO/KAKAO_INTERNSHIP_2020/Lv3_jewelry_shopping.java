package kakao_internship_2020;

// 2020 카카오 인턴십 - 보석 쇼핑
// https://school.programmers.co.kr/learn/courses/30/lessons/67258

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;

public class Lv3_jewelry_shopping {
    public static void main(String[] args) {
        String[] gems = {"DIA", "RUBY", "RUBY", "DIA", "DIA", "EMERALD", "SAPPHIRE", "DIA","RUBY", "DIA"};

        int[] result = solution(gems);
        for (int s : result) System.out.println(s);
    }

    public static int[] solution(String[] gems) {

        HashSet<String> gemSet = new HashSet<>(Arrays.asList(gems));
        int gemNum = gemSet.size();
        if (gems.length == 1 || gemNum == 1) return new int[]{1,1};
        if (gems.length == gemNum) return new int[]{1, gems.length};

        int minDist = gems.length+1;
        int minStart = 0, minEnd = 0;

//        int start = 0;
//        int end = gemNum-1;

        HashMap<String, Integer> map = new HashMap<>();
        int start = 0;
        for (int end = 0; end < gems.length; end++) {
            map.put(gems[end], map.getOrDefault(gems[end], 0)+1);

            while (map.get(gems[start]) > 1) {
                map.put(gems[start], map.get(gems[start])-1);
                start++;
            }

            if (map.size() == gemNum) {
                if (end - start < minDist) {
                    minDist = end - start;
                    minStart = start;
                    minEnd = end;
                }
            }
        }

        // 효율성 1, 6번만 통과
//        while (end < gems.length) {

//            HashSet<String> curSet = new HashSet<>(Arrays.asList(Arrays.copyOfRange(gems, start, end+1)));
//            if (curSet.size() < gemNum) {
//                end++;
//            } else if (curSet.size() == gemNum) {
//                if (end - start + 1 < minDist) {
//                    minDist = end - start + 1;
//                    minStart = start;
//                    minEnd = end;
//                    if (minDist == gemNum) break;
//                }
//                start++;
//            }
//        }

        int[] answer = {minStart+1, minEnd+1};
        return answer;
    }
}
