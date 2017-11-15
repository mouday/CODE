#条件语句
a=1
if a==1
    puts "a is 1"
elsif a==2
    puts "a is 2"
else
    puts "a is else"
end

#分支语句，增加可读性
case a
    when 1 then puts "a is 1"
    when 2 then puts "a is 2"
    when 3,4,5 then puts "a is in [3,4,5]"
    else puts "a is else"
end

# 三元表达式
a=1
puts a==1 ? "one" : "not one"

