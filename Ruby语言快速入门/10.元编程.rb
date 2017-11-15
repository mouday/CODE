# 元编程 meta programming
# def say_hi_to_jim
#     "hi,jim"
# end

# def say_hi_to_li_lei
#     "hi,li lei"
# end

# def say_hi_to_han_mei_mei
#     "hi,han mei mei"
# end

#等价于：
["jim","li_lei","han_mei_mei"].each do|name|
    define_method "say_hi_to_#{name}"  do
        puts "hi,#{name}"
    end
end

say_hi_to_jim

[1,2,3].each do |e|
    define_method "hi_#{e}" do
        puts "==hi,#{e}"
    end
end
hi_1
hi_2
hi_3

eval("a = 1 ;b = 2 ; puts a+b")
