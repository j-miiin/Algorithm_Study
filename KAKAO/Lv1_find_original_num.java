
// 2021 카카오 채용연계형 인턴십

public class Lv1_find_original_num {

    public static void main(String[] args) {
        System.out.println(solution("123"));
    }

    public static int solution(String s) {

        String[] englishForNum = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

        String result_str = "";
        String temp_str = "";
        for (int i = 0; i < s.length(); i++) {

            Character cur = s.charAt(i);

            if (cur >= '0' && cur <= '9') {
                result_str += cur;
            } else {
                temp_str += cur;
                for (int j = 0; j < englishForNum.length; j++) {
                    if (temp_str.equals(englishForNum[j])) {
                        result_str += j;
                        temp_str = "";
                        break;
                    }
                }
            }
        }

        int answer = Integer.parseInt(result_str);
        return answer;
    }
}
