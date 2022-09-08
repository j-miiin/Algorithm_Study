package kakao_blind_recruitment_2021;

// 2021 카카오 블라인드 채용

import java.util.*;

public class Lv2_menu_renewal {
    public static void main(String[] args) {
//        String[] orders = {"ABCFG", "AC", "CDE", "ACDE", "BCFG", "ACDEH"};
//        int[] course = {2, 3, 4};

//        String[] orders = {"ABCDE", "AB", "CD", "ADE", "XYZ", "XYZ", "ACD"};
//        int[] course = {2,3,5};

        String[] orders = {"XYZ", "XWY", "WXA"};
        int[] course = {2,3,4};

        String[] ans = solution(orders, course);
        for (int i = 0; i < ans.length; i++) {
            System.out.println(ans[i]);
        }
    }

    public static String[] solution(String[] orders, int[] course) {
        HashMap<String, Integer> subsetMap = new HashMap<>();
        ArrayList<String> subMenuList = new ArrayList<>();

        for (int i = 0; i < orders.length; i++) {
            char[] curMenuCharArr = orders[i].toCharArray();
            Arrays.sort(curMenuCharArr);

            for (int j = 0; j < (1<<curMenuCharArr.length); j++) {
                String subMenu = "";
                for (int k = 0; k < curMenuCharArr.length; k++) {
                    if ((j & 1 << k) != 0) {
                        subMenu += curMenuCharArr[k];
                    }
                }
                if (subMenu != "") subMenuList.add(subMenu);
            }
        }

        addSubMenuToMap(subMenuList, course, subsetMap);

        List<Map.Entry<String, Integer>> entryList = new LinkedList<>(subsetMap.entrySet());
        entryList.sort(new Comparator<Map.Entry<String, Integer>>() {
            @Override
            public int compare(Map.Entry<String, Integer> o1, Map.Entry<String, Integer> o2) {
                return o2.getValue() - o1.getValue();
            }
        });

        ArrayList<String> result = new ArrayList<>();
        int[] maxTemp = new int[21];
        for (Map.Entry<String, Integer> entry: entryList) {
            String key = entry.getKey();
            Integer value = entry.getValue();
            int menuOrderNum = value;
            if (menuOrderNum >= 2) {
                if (menuOrderNum >= maxTemp[key.length()]) {
                    result.add(key);
                    maxTemp[key.length()] = subsetMap.get(key);
                }
            }
        }

        Collections.sort(result);

        String[] answer = result.toArray(new String[0]);
        return answer;
    }

    public static void addSubMenuToMap(ArrayList<String> subMenuList, int[] course, HashMap<String, Integer> subsetMap) {
        for (int i = 0; i < course.length; i++) {
            for (String menu: subMenuList) {
                if (course[i] == menu.length()) {
                    if (subsetMap.containsKey(menu)) {
                        int tmp = subsetMap.get(menu);
                        subsetMap.put(menu, tmp + 1);
                    } else {
                        subsetMap.put(menu, 1);
                    }
                }
            }
        }

    }
}
