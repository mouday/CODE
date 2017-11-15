# 循环for each loop while
# each：方法
[1,2,3].each{ |e|
    puts e
}

# for：关键字，for后面的变量是全局变量
for e in [1,2,3]
    puts e
end
puts e

#loop
i=0
loop do
    i=i+1
    puts i
    break if i>10
end

#while
j=0
begin
    j=j+1
    puts j
end while j<5