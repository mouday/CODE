# string 字符串
single_line="我是一个好孩子"
multiple_line=%Q{
    我是一个好孩子
    我今天想出去玩
}

puts single_line
puts multiple_line 

# symbol 不变的字符串
:color  #等同于：“color”.to_symbol
puts :color.class
puts single_line.class

#字符串插值（interpolition）
name="jim"
puts "hi,#{name}"

a=1
puts "hi,#{a}"